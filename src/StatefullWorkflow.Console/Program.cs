using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using StatefullWorkflow.Engine;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.DataAccess;

namespace StatefullWorkFlow.Console
{
    class Program
    {
        //public static Logger logger = LogManager.GetConsole.WriteLine("Standard");
        static void Main(string[] args)
        {
            var unitOfWork = new JsonUnitOfWork("Data");
            var workflowRepo = new WorkflowRepository(unitOfWork);

            var workflow = workflowRepo.Get(1);
            //Persistence.CurrentWorkflowName = workflow.Name;

            System.Console.WriteLine("Current Workflow: " + Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName).DisplayName);

            var ititialState = Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName).States.First(s => s.InitialState);
            Persistence.StateAccess.SetCurrentState(ititialState);

            System.Console.WriteLine("Creating State Machine. Any key to continue");
            Persistence.CurrentStateMachine = WorkflowInstance.ConfigureStateMachine(Persistence.WorkflowAccess.GetWorkflow(Persistence.CurrentWorkflowName), Persistence.StateAccess);
            System.Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.DisplayName);
            System.Console.ReadKey();

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

            System.Console.WriteLine("Enter any key to quit");
            System.Console.ReadKey();
        }

        private static void ChangeSingleTriggerState()
        {
            string trigger = Persistence.CurrentStateMachine.PermittedTriggers.First();
            System.Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.DisplayName);
            System.Console.WriteLine("Fire trigger:\"" + trigger + "\" press any key");
            System.Console.ReadKey();
            Persistence.CurrentStateMachine.Fire(trigger);
        }

        private static void ChangeYesNoTriggerState()
        {
            System.Console.WriteLine("Current State: " + Persistence.CurrentStateMachine.State.Name);
            System.Console.WriteLine("Fire trigger: [A]pprove");
            System.Console.WriteLine("Fire trigger: [D]eny");
            var key = System.Console.ReadKey();
            if (key.Key == ConsoleKey.A)
                Persistence.CurrentStateMachine.Fire("Approve");
            else
                Persistence.CurrentStateMachine.Fire("Deny");
        }
    }
}
