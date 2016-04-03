using StatefullWorkflow.DataAccess;
using StatefullWorkflow.Entities;
using StatefullWorkflow.Utilities;
using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Engine
{
    public class WorkflowProcesser
    {
        public static InstanceManager CreateWorkflowManager(Workflow workflow, IRepositoryHelper repoHelper)
        {
            Enforce.ArgumentNotNull(workflow, nameof(workflow));
            Enforce.ArgumentNotNull(repoHelper, nameof(repoHelper));

            var instance = new WorkflowInstance { WorkflowId = workflow.Id, CurrentStateId = workflow.StartState };
            var repo = repoHelper.GetWorkflowInstanceRepository(repoHelper.GetUnitOfWork());
            var id = repo.Insert(instance);

            if (!string.IsNullOrWhiteSpace(id))
            {
                repoHelper.GetUnitOfWork().SaveChanges();
                var statePersistance = new InstanceStatePersistence(instance.Id, repoHelper);
                var stateMachine = ConfigureStateMachine(workflow, statePersistance, repoHelper);
                return new InstanceManager(instance, workflow, stateMachine, statePersistance, repoHelper);
            }
            return null;
        }

        public static StateMachine<State, string> ConfigureStateMachine(Workflow workflow, InstanceStatePersistence statePersistance, IRepositoryHelper repoHelper)
        {
            Enforce.ArgumentNotNull(workflow, nameof(workflow));
            Enforce.ArgumentNotNull(statePersistance, nameof(statePersistance));
            Enforce.ArgumentNotNull(repoHelper, nameof(repoHelper));

            var stateMachine = new StateMachine<State, string>(statePersistance.GetCurrentState, statePersistance.SetCurrentState);

            //  Get a distinct list of states with a trigger from state configuration
            //  "State => Trigger => TargetState
            var stateRepo = repoHelper.GetStateRepository(repoHelper.GetUnitOfWork());
            var transitionRepo = new StateTransitionRepository(repoHelper.GetUnitOfWork());

            var states = transitionRepo.Where(t => t.WorkflowId == workflow.Id).Select(t => stateRepo.Get(t.StateId)).Distinct().ToList();
            //var transitions = transitionRepo.Where(s => s.WorkflowId == workflow.Id).ToList();

            //  Assigning triggers to states
            foreach (var state in states)
            {
                var transitions = transitionRepo.Where(t => t.StateId == state.Id).Select(t => new { Trigger = t.Trigger, TargetState = stateRepo.Get(t.TargetStateId) }).ToList();

                foreach (var tran in transitions)
                {
                    if (tran.TargetState != null)
                    {
                        stateMachine.Configure(state).Permit(tran.Trigger, tran.TargetState);
                    }
                }
            }

            return stateMachine;
        }
    }
}
