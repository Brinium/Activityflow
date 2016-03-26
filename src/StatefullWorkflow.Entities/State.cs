using Stateless;
using System;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class State : Entity<int>
    {
        public string DisplayName { get; set; }

        public int WorkflowId { get; set; }

        //public Action<StateMachine<State, string>.Transition> OnEntryStateAction { get; set; }
        public string OnEntryStateAction { get; set; }

        //public Action<StateMachine<State, string>.Transition> OnExitStateAction { get; set; }
        public string OnExitStateAction { get; set; }

        public State()
        {
        }
    }
}