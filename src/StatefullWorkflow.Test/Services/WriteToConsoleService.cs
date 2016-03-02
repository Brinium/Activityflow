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
            NLog.LogManager.GetLogger("Standard").Info("Entered Source : " + entryAction.Source.Name);
            NLog.LogManager.GetLogger("Standard").Info("Entered Trigger : " + entryAction.Trigger);
            NLog.LogManager.GetLogger("Standard").Info("Entered Destination : " + entryAction.Destination.Name);
            var triggers = String.Join(",", Persistence.CurrentStateMachine.PermittedTriggers);
            NLog.LogManager.GetLogger("Standard").Info("Permitted Triggers : " + triggers);
        }

        public void OnExitStateAction(StateMachine<State, string>.Transition exitAction)
        {
            NLog.LogManager.GetLogger("Standard").Info("Exited Source : " + exitAction.Source.Name);
            NLog.LogManager.GetLogger("Standard").Info("Exited Trigger : " + exitAction.Trigger);
            NLog.LogManager.GetLogger("Standard").Info("Exited Destination : " + exitAction.Destination.Name);
        }
    }
}
