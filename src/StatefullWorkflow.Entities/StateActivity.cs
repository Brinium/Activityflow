using System;
using System.Collections.Generic;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class StateActivity : Entity<int>
    {
        public int WorkflowId { get; set; }
        public int StateId { get; set; }
        public string DisplayName { get; set; }

        public IList<string> AuthorisedRoles { get; set; }
        public IList<string> AuthorisedUsers { get; set; }

        public StateActivity()
        {
        }
    }
}