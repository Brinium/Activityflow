using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class WorkflowInstance : Entity<int>
    {
        public int WorkflowId { get; set; }

        public int CurrentStateId { get; set; }

        public WorkflowInstance()
        {
        }
    }
}
