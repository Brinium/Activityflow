using StatefullWorkflow.Entities;
using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace StatefullWorkflow.Config.WebService.DataContracts
{
    [DataContract]
    public class StateDC
    {
        private State _state;

        [DataMember]
        public int Id
        {
            get { return _state.Id; }
            set { _state.Id = value; }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _state.DisplayName; }
            set { _state.DisplayName = value; }
        }

        [DataMember]
        public int WorkflowId
        {
            get { return _state.WorkflowId; }
            set { _state.WorkflowId = value; }
        }

        [DataMember]
        public string OnEntryStateAction
        {
            get { return _state.OnEntryStateAction; }
            set { _state.OnEntryStateAction = value; }
        }

        [DataMember]
        public string OnExitStateAction
        {
            get { return _state.OnExitStateAction; }
            set { _state.OnExitStateAction = value; }
        }

        public StateDC()
        {
        }

        public StateDC(State state)
        {
            _state = state;
        }
    }
}