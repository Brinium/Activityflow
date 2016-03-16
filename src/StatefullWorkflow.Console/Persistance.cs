using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;
using StatefullWorkFlow.Test.Database;
using Stateless;

namespace StatefullWorkFlow.Console
{
    public static class Persistence
    {
        public static StateMachine<State, string> CurrentStateMachine { get; set; }
        public static string CurrentWorkflowName { get; set; }

        public static IWorkflowRepository WorkflowAccess { get; set; }
        public static IStateRepository StateAccess { get; set; }

        static Persistence()
        {
            WorkflowAccess = new WorkflowRepository();
            StateAccess = new StateRepository();
        }
    }
}
