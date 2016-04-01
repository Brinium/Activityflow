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
        public int Id
        {
            get { return _workflow.Id; }
            set { _workflow.Id = value; }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _workflow.DisplayName; }
            set { _workflow.DisplayName = value; }
        }

        [DataMember]
        public int StartState
        {
            get { return _workflow.StartState; }
            set { _workflow.StartState = value; }
        }

        [DataMember]
        public IList<State> States { get; set; }

        [DataMember]
        public IList<StateTransition> Transitions { get; set; }

        [DataMember]
        public IList<StateActivity> Activities { get; set; }

        public WorkflowDC()
        {

        }

        public WorkflowDC(Workflow workflow)
        {
            _workflow = workflow;
            States = new List<State>();
            Transitions = new List<StateTransition>();
            Activities = new List<StateActivity>();
        }
    }
}