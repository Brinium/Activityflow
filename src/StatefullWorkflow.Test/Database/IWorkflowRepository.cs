using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatefullWorkflow.Configuration;

namespace StatefullWorkFlow.Test.Database
{
    public interface IWorkflowRepository
    {
        string InsertWorkflow(Workflow workflow);
        string UpdateWorkflow(Workflow workflow);
        Workflow GetWorkflow(string workflowName);
        void DeleteWorkflow(string workflowName);
    }
}
