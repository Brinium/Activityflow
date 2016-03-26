using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class StateTransition : Entity<int>
    {
        public string Trigger { get; set; }
        public string DisplayName { get; set; }
        public int WorkflowId { get; set; }
        public int StateId { get; set; }
        public int TargetStateId { get; set; }

        public StateTransition()
        {
        }
    }
}
