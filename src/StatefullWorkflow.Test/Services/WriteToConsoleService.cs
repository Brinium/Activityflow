using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;
using Stateless;

namespace StatefullWorkFlow.Test.Services
{
    public class WriteToConsoleService : IStateEventService
    {
        public void OnEntryStateAction(StateMachine<State, string>.Transition entryAction)
        {
            Console.WriteLine("Entered Source : " + entryAction.Source.Name);
            Console.WriteLine("Entered Trigger : " + entryAction.Trigger);
            Console.WriteLine("Entered Destination : " + entryAction.Destination.Name);
            var triggers = String.Join(",", Persistence.CurrentStateMachine.PermittedTriggers);
            Console.WriteLine("Permitted Triggers : " + triggers);
        }

        public void OnExitStateAction(StateMachine<State, string>.Transition exitAction)
        {
            Console.WriteLine("Exited Source : " + exitAction.Source.Name);
            Console.WriteLine("Exited Trigger : " + exitAction.Trigger);
            Console.WriteLine("Exited Destination : " + exitAction.Destination.Name);
        }
    }
}
