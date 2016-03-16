using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class WorkflowStateActivity
    {
        public string State { get; set; }
        public string Activity { get; set; }
        public List<string> AuthorisedRoles { get; set; }
        public List<string> AuthorisedUsers { get; set; }

        public WorkflowStateActivity() { }
    }
}
