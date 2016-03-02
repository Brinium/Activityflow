using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatefullWorkflow.Configuration;

namespace StatefullWorkFlow.Test.Database
{
    public class WorkflowRepository : IWorkflowRepository
    {
        public static Dictionary<string, Workflow> Workflows { get; set; }

        public WorkflowRepository()
        {
            Workflows = new Dictionary<string, Workflow>();
            InsertWorkflow(DeserializeWorkflow(@"WorkflowConfig\ExampleWorkflow.json"));
        }

        public string InsertWorkflow(Workflow workflow)
        {
            if (workflow == null) return null;

            if (!Workflows.ContainsKey(workflow.Name))
            {
                Workflows.Add(workflow.Name, workflow);
            }
            else
            {
                return UpdateWorkflow(workflow);
            }
            return workflow.Name;
        }

        public string UpdateWorkflow(Workflow workflow)
        {
            if (workflow == null) return null;

            if (Workflows.ContainsKey(workflow.Name))
            {
                Workflows[workflow.Name] = workflow;
            }
            else
            {
                return InsertWorkflow(workflow);
            }
            return workflow.Name;
        }

        public Workflow GetWorkflow(string workflowName)
        {
            if (String.IsNullOrWhiteSpace(workflowName)) return null;

            return Workflows[workflowName];
        }

        public void DeleteWorkflow(string workflowName)
        {
            if (String.IsNullOrWhiteSpace(workflowName)) return;

            if (Workflows.ContainsKey(workflowName))
                Workflows.Remove(workflowName);
        }

        private static Workflow DeserializeWorkflow(string source)
        {
            Workflow workflow = null;

            var fileInfo = new FileInfo(source);
            if (fileInfo.Exists == false)
            {
                throw new ApplicationException("RequestPromotion.Configure - File not found");
            }

            string json = string.Empty;
            try
            {
                using (StreamReader sr = fileInfo.OpenText())
                {
                    json = sr.ReadToEnd();
                    sr.Close();
                }

                workflow = JsonConvert.DeserializeObject<Workflow>(json);
            }
            catch (Exception ex)
            {
                NLog.LogManager.GetLogger("Standard").Error(ex, ex.Message);
            }

            return workflow;
        }
    }
}
