using System;
using StatefullWorkflow.Engine;
using Stateless;
using StatefullWorkflow.Entities;

namespace StatefullWorkFlow.Console
{
    public class WriteToConsoleService : IStateEventService
    {
        public void OnEntryStateAction(StateMachine<State, string>.Transition entryAction)
        {
            System.Console.WriteLine("Entered Source : " + entryAction.Source.DisplayName);
            System.Console.WriteLine("Entered Trigger : " + entryAction.Trigger);
            System.Console.WriteLine("Entered Destination : " + entryAction.Destination.DisplayName);
            var triggers = String.Join(",", Persistence.CurrentInstanceManager.StateMachine.PermittedTriggers);
            System.Console.WriteLine("Permitted Triggers : " + triggers);
        }

        public void OnExitStateAction(StateMachine<State, string>.Transition exitAction)
        {
            System.Console.WriteLine("Exited Source : " + exitAction.Source.DisplayName);
            System.Console.WriteLine("Exited Trigger : " + exitAction.Trigger);
            System.Console.WriteLine("Exited Destination : " + exitAction.Destination.DisplayName);
        }
    }
}
