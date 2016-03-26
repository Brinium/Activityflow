using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class InstanceStateActivity
    {
        public int WorkflowInstanceId { get; set; }
        public int StateId { get; set; }
        public int ActivityId { get; set; }
        public List<string> AuthorisedRoles { get; set; }
        public List<string> AuthorisedUsers { get; set; }

        public InstanceStateActivity() { }
    }
}
