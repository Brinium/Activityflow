using System;
using System.Collections.Generic;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class StateActivity : Entity
    {
        public string WorkflowId { get; set; }
        public string StateId { get; set; }
        public string DisplayName { get; set; }

        public IList<string> AuthorisedRoles { get; set; }
        public IList<string> AuthorisedUsers { get; set; }

        public StateActivity()
        {
            AuthorisedRoles = new List<string>();
            AuthorisedUsers = new List<string>();
        }
    }
}