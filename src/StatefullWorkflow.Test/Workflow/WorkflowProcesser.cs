using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stateless;

namespace ConfigurableStatelessMachine
{
    public class WorkflowProcesser
    {

        public static StateMachine<State, string> ConfigureStateMachine(Workflow workflow)
        {
            //Enforce.That(string.IsNullOrEmpty(this.step.State) == false, "WorkflowProcessor.Confgiure - step.State can not be empty");

            var stateMachine = new StateMachine<State, string>(Persistance.GetCurrentState, Persistance.SetCurrentState);

            //  Get a distinct list of states with a trigger from state configuration
            //  "State => Trigger => TargetState
            var states = workflow.States.Where(state => workflow.StateConfigs.Any(s => s.State == state.Name)).Select(s => s).ToList();

            //  Assigning triggers to states
            states.ForEach(state =>
            {
                //var activities = 
                var triggers = workflow.StateConfigs.AsQueryable()
                                   .Where(config => config.State == state.Name)
                                   .ToList();

                triggers.ForEach(trig =>
                {
                    stateMachine.Configure(state)
                        .OnEntry(s => state.OnEntryStateAction(s))
                        .OnExit((s) => state.OnExitStateAction(s))
                        .Permit(trig.Trigger, workflow.States.First(tState => tState.Name == trig.TargetState));
                });
            });

            return stateMachine;
        }
    }
}
