using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class StateTransition : Entity
    {
        public string Trigger { get; set; }
        public string DisplayName { get; set; }
        public string WorkflowId { get; set; }
        public string StateId { get; set; }
        public string TargetStateId { get; set; }

        public StateTransition()
        {
        }
    }
}
