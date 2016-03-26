using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Entities;
using Stateless;
using StatefullWorkflow.DataAccess;
using StatefullWorkflow.DataAccess.Json;

namespace StatefullWorkflow.Engine
{
    public class WorkflowInstance
    {
        public int InstanceId { get; set; }
        public Workflow Workflow { get; set; }
        public StateMachine<State, string> StateMachine { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public WorkflowInstance(Workflow workflow, IUnitOfWork unitOfWork)
        {
            Workflow = workflow;
            UnitOfWork = unitOfWork;
            StateMachine = ConfigureStateMachine()
        }

        private static Step GetCurrentStep()
        {
            var unitOfWork = new JsonUnitOfWork("Data");
            var repo = new WorkflowInstanceRepository(unitOfWork);
            return repo.GetCurrentState(InstanceId);
        }

        private static void SetCurrentStep(Step step)
        {
            var unitOfWork = new JsonUnitOfWork("Data");
            var repo = new WorkflowInstanceRepository(unitOfWork);
            repo.SetCurrentState(step.WorkflowInstanceId, step.State);
            repo.SaveChanges();
        }

        public static StateMachine<Step, string> ConfigureStateMachine(Workflow workflow, int instanceId, IUnitOfWork unitOfWork)
        {
            //Enforce.That(string.IsNullOrEmpty(this.step.State) == false, "WorkflowProcessor.Confgiure - step.State can not be empty");

            var stateMachine = new StateMachine<Step, string>(GetCurrentStep, SetCurrentStep);
            
            //  Get a distinct list of states with a trigger from state configuration
            //  "State => Trigger => TargetState
            var stateRepo = new StateRepository(unitOfWork);
            var transitionRepo = new StateTransitionRepository(unitOfWork);

            var states = stateRepo.Where(s => s.WorkflowId == workflow.Id).Select(s => new Step(instanceId, workflow.Id, s)).ToList();
            //var transitions = transitionRepo.Where(s => s.WorkflowId == workflow.Id).ToList();

            //  Assigning triggers to states
            foreach (var state in states)
            {
                var triggers = transitionRepo.Where(trans => trans.StateId == state.State.Id).ToList();

                foreach (var trig in triggers)
                {
                    stateMachine.Configure(state)
                        .Permit(trig.Trigger, new Step(instanceId, workflow.Id, stateRepo.Get(trig.TargetStateId)));
                }
            }
            
            return stateMachine;
        }
    }
}
