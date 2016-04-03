using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Config.WebService.DataContracts
{
    [DataContract]
    public class StateTransitionDC
    {
        private StateTransition _transition;

        [DataMember]
        public string Id
        {
            get { return _transition.Id; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.Id = value;
            }
        }

        [DataMember]
        public string Trigger
        {
            get { return _transition.Trigger; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.Trigger = value;
            }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _transition.DisplayName; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.DisplayName = value;
            }
        }

        [DataMember]
        public string WorkflowId
        {
            get { return _transition.WorkflowId; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.WorkflowId = value;
            }
        }

        [DataMember]
        public string StateId
        {
            get { return _transition.StateId; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.StateId = value;
            }
        }

        [DataMember]
        public string TargetStateId
        {
            get { return _transition.TargetStateId; }
            set
            {
                if (_transition == null) _transition = new StateTransition();
                _transition.TargetStateId = value;
            }
        }

        public StateTransitionDC()
        {
            _transition = new StateTransition();
        }

        internal StateTransitionDC(StateTransition state)
        {
            _transition = state;
        }

        internal StateTransition GetStateTransition()
        {
            return _transition;
        }
    }
}
