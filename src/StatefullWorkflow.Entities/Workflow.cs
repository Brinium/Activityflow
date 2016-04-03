using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class Workflow : Entity
    {
        public string DisplayName { get; set; }

        public string StartState { get; set; }

        public Workflow()
        {
        }
    }
}
