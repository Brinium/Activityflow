using System;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class State : Entity<int>, IEquatable<State>
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

        public override string ToString()
        {
            return String.Format("WorkflowId:{0}, Id:{1}, Name:\"{2}\"", WorkflowId, Id, DisplayName);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == typeof(State) && this.Equals((State)obj);
        }

        public bool Equals(State other)
        {
            return other != null && Id == other.Id ;
        }
    }
}