using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConfigurableStatelessMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Persistance.CurrentWorkflow = DeserializeWorkflow(@"WorkflowConfig\ExampleWorkflow.json");
            Console.WriteLine("DeserializeWorkflow: " + Persistance.CurrentWorkflow.WorkflowType);

            var ititialState = Persistance.CurrentWorkflow.States.First(s => s.InitialState);
            Persistance.SetCurrentState(ititialState);

            Console.WriteLine("Creating State Machine. Any key to continue");
            Persistance.CurrentStateMachine = WorkflowProcesser.ConfigureStateMachine(Persistance.CurrentWorkflow);
            Console.WriteLine("Current State: " + Persistance.CurrentStateMachine.State.DisplayName);
            Console.ReadKey();

            while (Persistance.CurrentStateMachine.State.Name != "Promoted" && Persistance.CurrentStateMachine.State.Name != "PromotionDenied")
            {
                if (Persistance.CurrentStateMachine.PermittedTriggers.Any(t => t == "Approve" || t == "Deny"))
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
            string trigger = Persistance.CurrentStateMachine.PermittedTriggers.First();
            Console.WriteLine("Current State: " + Persistance.CurrentStateMachine.State.DisplayName);
            Console.WriteLine("Fire trigger:\"" + trigger + "\" press any key");
            Console.ReadKey();
            Persistance.CurrentStateMachine.Fire(trigger);
        }

        private static void ChangeYesNoTriggerState()
        {
            Console.WriteLine("Current State: " + Persistance.CurrentStateMachine.State.Name);
            Console.WriteLine("Fire trigger: [A]pprove");
            Console.WriteLine("Fire trigger: [D]eny");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.A)
                Persistance.CurrentStateMachine.Fire("Approve");
            else
                Persistance.CurrentStateMachine.Fire("Deny");
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
