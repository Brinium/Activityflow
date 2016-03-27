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
    public static class WorkflowProcesser
    {
        public static InstanceManager CreateWorkflowManager(Workflow workflow, IUnitOfWork unitOfWork)
        {
            Enforce.ArgumentNotNull(workflow, nameof(workflow));
            Enforce.ArgumentNotNull(unitOfWork, nameof(unitOfWork));

            var instance = new WorkflowInstance { WorkflowId = workflow.Id, CurrentStateId = workflow.StartState };
            var repo = new WorkflowInstanceRepository(unitOfWork);
            var id = repo.Insert(instance);

            if (id.HasValue)
            {
                repo.SaveChanges();
                var statePersistance = new InstanceStatePersistence(instance.Id, unitOfWork);
                var stateMachine = ConfigureStateMachine(workflow, statePersistance, unitOfWork);
                return new InstanceManager(instance, workflow, stateMachine, statePersistance, unitOfWork);
            }
            return null;
        }

        public static StateMachine<State, string> ConfigureStateMachine(Workflow workflow, InstanceStatePersistence statePersistance, IUnitOfWork unitOfWork)
        {
            Enforce.ArgumentNotNull(workflow, nameof(workflow));
            Enforce.ArgumentNotNull(statePersistance, nameof(statePersistance));
            Enforce.ArgumentNotNull(unitOfWork, nameof(unitOfWork));

            var stateMachine = new StateMachine<State, string>(statePersistance.GetCurrentState, statePersistance.SetCurrentState);

            //  Get a distinct list of states with a trigger from state configuration
            //  "State => Trigger => TargetState
            var stateRepo = new StateRepository(unitOfWork);
            var transitionRepo = new StateTransitionRepository(unitOfWork);

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
