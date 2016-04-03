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
        public string Id
        {
            get { return _state.Id; }
            set
            {
                if (_state == null) _state = new State();
                _state.Id = value;
            }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _state.DisplayName; }
            set
            {
                if (_state == null) _state = new State();
                _state.DisplayName = value;
            }
        }

        [DataMember]
        public string WorkflowId
        {
            get { return _state.WorkflowId; }
            set
            {
                if (_state == null) _state = new State();
                _state.WorkflowId = value;
            }
        }

        [DataMember]
        public string OnEntryStateAction
        {
            get { return _state.OnEntryStateAction; }
            set
            {
                if (_state == null) _state = new State();
                _state.OnEntryStateAction = value;
            }
        }

        [DataMember]
        public string OnExitStateAction
        {
            get { return _state.OnExitStateAction; }
            set
            {
                if (_state == null) _state = new State();
                _state.OnExitStateAction = value;
            }
        }

        public StateDC()
        {
            _state = new State();
        }

        internal StateDC(State state)
        {
            _state = state;
        }

        internal State GetState()
        {
            return _state;
        }
    }
}