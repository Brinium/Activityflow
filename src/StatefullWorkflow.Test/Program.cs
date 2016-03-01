using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;

namespace StatefullWorkFlow.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Persistence.CurrentWorkflow = DeserializeWorkflow(@"WorkflowConfig\ExampleWorkflow.json");
            Console.WriteLine("DeserializeWorkflow: " + Persistence.CurrentWorkflow.WorkflowType);

            var ititialState = Persistence.CurrentWorkflow.States.First(s => s.InitialState);
            Persistence.SetCurrentState(ititialState);

            Console.WriteLine("Creating State Machine. Any key to continue");
            Persistence.CurrentStateMachine = WorkflowProcesser.ConfigureStateMachine(Persistence.CurrentWorkflow, Persistence.GetCurrentState, Persistence.SetCurrentState);
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

        private static Workflow DeserializeWorkflow(string source)
        {
            var fileInfo = new FileInfo(source);

            if (fileInfo.Exists == false)
            {
                throw new ApplicationException("RequestPromotion.Configure - File not found");
            }

            string json = string.Empty;
            using (StreamReader sr = fileInfo.OpenText())
            {
                json = sr.ReadToEnd();
                sr.Close();
            }

            var workflow = JsonConvert.DeserializeObject<Workflow>(json);

            return workflow;
        }
    }
}
