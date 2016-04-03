using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class Activity : Entity
    {
        public string WorkflowId { get; set; }
        public string DisplayName { get; set; }

        public List<string> AuthorisedRoles { get; set; }
        public List<string> AuthorisedUsers { get; set; }

        public Activity()
        {
        }
    }
}
