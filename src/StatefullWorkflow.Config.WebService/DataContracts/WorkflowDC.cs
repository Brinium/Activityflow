using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.Config.WebService.DataContracts
{
    [DataContract]
    public class WorkflowDC
    {
        private Workflow _workflow;

        [DataMember]
        public string Id
        {
            get { return _workflow.Id; }
            set
            {
                if (_workflow == null) _workflow = new Workflow();
                _workflow.Id = value;
            }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _workflow.DisplayName; }
            set
            {
                if (_workflow == null) _workflow = new Workflow();
                _workflow.DisplayName = value;
            }
        }

        [DataMember]
        public string StartState
        {
            get { return _workflow.StartState; }
            set
            {
                if (_workflow == null) _workflow = new Workflow();
                _workflow.StartState = value;
            }
        }

        [DataMember]
        public IList<StateDC> States { get; set; }

        [DataMember]
        public IList<StateTransitionDC> Transitions { get; set; }

        [DataMember]
        public IList<StateActivityDC> Activities { get; set; }

        public WorkflowDC()
        {
            _workflow = new Workflow();
            States = new List<StateDC>();
            Transitions = new List<StateTransitionDC>();
            Activities = new List<StateActivityDC>();
        }

        internal WorkflowDC(Workflow workflow)
        {
            _workflow = workflow;
            States = new List<StateDC>();
            Transitions = new List<StateTransitionDC>();
            Activities = new List<StateActivityDC>();
        }

        internal Workflow GetWorkflow()
        {
            return _workflow;
        }
    }
}