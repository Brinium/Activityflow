using System;
using System.Reflection;

namespace StatefullWorkflow.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool InitialState { get; set; }

        public string OnEntryStateAction { get; set; }
        public string OnExitStateAction { get; set; }
        
        public State() { }
    }
}