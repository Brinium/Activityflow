using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;

namespace StatefullWorkFlow.Console
{
    class Program
    {
        //public static Logger logger = LogManager.GetConsole.WriteLine("Standard");
        static void Main(string[] args)
        {
            var workflow = Persistence.WorkflowAccess.GetWorkflow("RequestPromotion");
            Persistence.CurrentWorkflowName = workflow.Name;

            Console.WriteLine("Current Workflow: " + Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName).DisplayName);

            var ititialState = Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName).States.First(s => s.InitialState);
            Persistence.StateAccess.SetCurrentState(ititialState);

            Console.WriteLine("Creating State Machine. Any key to continue");
            Persistence.CurrentStateMachine = WorkflowProcesser.ConfigureStateMachine(Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName), Persistence.StateAccess);
            Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.DisplayName);
            Console.ReadKey();

            while (Persistence.CurrentStateMachine.State.Name != "Promoted" && Persistence.CurrentStateMachine.State.Name != "PromotionDenied")
            {
                if (Persistence.CurrentStateMachine.PermittedTriggers.Any(t => t == "Approve" || t == "Deny"))
                {
                    ChangeYesNoTriggerState();
                }
                else
                {
                    ChangeSingleTriggerState();
                }
            }

            Console.WriteLine("Enter any key to quit");
            Console.ReadKey();
        }

        private static void ChangeSingleTriggerState()
        {
            string trigger = Persistence.CurrentStateMachine.PermittedTriggers.First();
            Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.DisplayName);
            Console.WriteLine("Fire trigger:\"" + trigger + "\" press any key");
            Console.ReadKey();
            Persistence.CurrentStateMachine.Fire(trigger);
        }

        private static void ChangeYesNoTriggerState()
        {
            Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.Name);
            Console.WriteLine("Fire trigger: [A]pprove");
            Console.WriteLine("Fire trigger: [D]eny");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.A)
                Persistence.CurrentStateMachine.Fire("Approve");
            else
                Persistence.CurrentStateMachine.Fire("Deny");
        }
    }
}
