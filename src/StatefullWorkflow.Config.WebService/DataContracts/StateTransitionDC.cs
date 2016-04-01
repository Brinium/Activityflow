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
        public int Id
        {
            get { return _transition.Id; }
            set { _transition.Id = value; }
        }

        [DataMember]
        public string Trigger
        {
            get { return _transition.Trigger; }
            set { _transition.Trigger = value; }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _transition.DisplayName; }
            set { _transition.DisplayName = value; }
        }

        [DataMember]
        public int WorkflowId
        {
            get { return _transition.WorkflowId; }
            set { _transition.WorkflowId = value; }
        }

        [DataMember]
        public int StateId
        {
            get { return _transition.StateId; }
            set { _transition.StateId = value; }
        }

        [DataMember]
        public int TargetStateId
        {
            get { return _transition.TargetStateId; }
            set { _transition.TargetStateId = value; }
        }

        public StateTransitionDC()
        {
        }

        public StateTransitionDC(StateTransition state)
        {
            _transition = state;
        }
    }
}
