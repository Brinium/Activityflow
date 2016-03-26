using System;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class StateActivity : Entity<int>
    {
        public int WorkflowId { get; set; }
        public int StateId { get; set; }
        public int ActivityId { get; set; }

        public StateActivity()
        {
        }
    }
}