using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class WorkflowInstance : Entity
    {
        public string WorkflowId { get; set; }

        public string CurrentStateId { get; set; }

        public WorkflowInstance()
        {
        }
    }
}
