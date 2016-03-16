using System;
using System.Reflection;
using Stateless;

namespace StatefullWorkflow.Entities
{
    public class WorkflowState : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool InitialState { get; set; }

        /// <summary>
        /// Stateless has OnEntry/OnExit actions that can be run, but this just illustrates how you
        /// could go about creating your own states that run their own actions where good encapsulation is
        /// observed
        /// </summary>
        public Action<StateMachine<State, string>.Transition> OnEntryStateAction { get; set; }

        /// <summary>
        /// Stateless has OnEntry/OnExit actions that can be run, but this just illustrates how you
        /// could go about creating your own states that run their own actions where good encapsulation is
        /// observed
        /// </summary>
        public Action<StateMachine<State, string>.Transition> OnExitStateAction { get; set; }

        public WorkflowState() { }
    }
}