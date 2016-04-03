using Newtonsoft.Json;
using StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatefullWorkflow.Config.WebService.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var json = ReadFile(@".\Data\Workflows.json");

            var workflow = DeserializeJsonEntityArray(json);
            Thread.Sleep(5000);

            using (var client = new StatefullConfigClient())
            {
                var finished = client.InsertWorkflow(workflow);
            }
        }

        public static string ReadFile(string fileName)
        {
            string text;
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            return text;
        }

        public static WorkflowDC DeserializeJsonEntityArray(string json)
        {
            var workflow = JsonConvert.DeserializeObject<WorkflowDC>(json);
            return workflow;
        }
    }
}
