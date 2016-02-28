using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Stateless;

namespace ConfigurableStatelessMachine
{
    [JsonConverter(typeof(StateConverter))]
    public class State
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

        public State() { }

        public State(string name, string displayName, Action<StateMachine<State, string>.Transition> onEntryStateAction, Action<StateMachine<State, string>.Transition> onExitStateAction)
        {
            Name = name;
            DisplayName = displayName;
            OnEntryStateAction = onEntryStateAction;
            OnExitStateAction = onExitStateAction;
        }
    }
}