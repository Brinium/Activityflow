using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using StatefullWorkflow.Engine;
using StatefullWorkflow.DataAccess;

namespace StatefullWorkFlow.Console
{
    class Program
    {
        static readonly IRepositoryHelper repoHelper = new RepositoryHelper("Data");

        //public static Logger logger = LogManager.GetConsole.WriteLine("Standard");
        static void Main(string[] args)
        {
            var unitOfWork = repoHelper.GetUnitOfWork();
            var workflowRepo = repoHelper.GetWorkflowRepository(unitOfWork);

            var workflow = workflowRepo.Get("6656c1a5-8a85-4f6f-9657-04615a728bc7");
            //Persistence.CurrentWorkflowName = workflow.Name;

            System.Console.WriteLine("Current Workflow: " + workflow.DisplayName);

            Persistence.CurrentInstanceManager = WorkflowProcesser.CreateWorkflowManager(workflow, repoHelper);

            var dotGraph = Persistence.CurrentInstanceManager.StateMachine.ToDotGraph();


            System.Console.WriteLine("Creating State Machine. Any key to continue");
            System.Console.WriteLine("Current State: " + Persistence.CurrentInstanceManager.StateMachine.State.DisplayName);
            System.Console.ReadKey();

            var canFire = Persistence.CurrentInstanceManager.StateMachine.CanFire("DesirePromotion");
            var state = Persistence.CurrentInstanceManager.StateMachine.State;
            var triggers = Persistence.CurrentInstanceManager.StateMachine.PermittedTriggers.ToList();

            while (Persistence.CurrentInstanceManager.StateMachine.State.DisplayName != "Promoted" && Persistence.CurrentInstanceManager.StateMachine.State.DisplayName != "PromotionDenied")
            {
                if (Persistence.CurrentInstanceManager.StateMachine.PermittedTriggers.Any(t => t == "Approve" || t == "Deny"))
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
            string trigger = Persistence.CurrentInstanceManager.StateMachine.PermittedTriggers.FirstOrDefault();
            System.Console.WriteLine("Current State: " + Persistence.CurrentInstanceManager.StateMachine.State.DisplayName);
            System.Console.WriteLine("Fire trigger:\"" + trigger + "\" press any key");
            System.Console.ReadKey();
            Persistence.CurrentInstanceManager.StateMachine.Fire(trigger);
        }

        private static void ChangeYesNoTriggerState()
        {
            System.Console.WriteLine("Current State: " + Persistence.CurrentInstanceManager.StateMachine.State.DisplayName);
            System.Console.WriteLine("Fire trigger: [A]pprove");
            System.Console.WriteLine("Fire trigger: [D]eny");
            var key = System.Console.ReadKey();
            if (key.Key == ConsoleKey.A)
                Persistence.CurrentInstanceManager.StateMachine.Fire("Approve");
            else
                Persistence.CurrentInstanceManager.StateMachine.Fire("Deny");
        }
    }
}
