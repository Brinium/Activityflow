using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Configuration
{
    public class StateActivity
    {
        public string State { get; set; }
        public string Activity { get; set; }
        public List<string> AuthorisedRoles { get; set; }
        public List<string> AuthorisedUsers { get; set; }

        public StateActivity()
        {
            //AuthorisedRoles = new List<string>();
            //AuthorisedUsers = new List<string>();
        }
    }
}
