using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Engine
{
    /// <summary>
    /// Step presents the State of a Workflowinstance and accepts and answer from 
    /// a user that will be used to trigger a transition to a different state.
    /// </summary>
    public class Step
    {
        #region Properties

        public int WorkflowInstanceId { get; set; }
        public int WorkflowId { get; set; }
        public string StepId { get; set; }
        public State State { get; set; }
        public State PreviousState { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public string Answer { get; set; }
        public DateTime Created { get; set; }
        public string AnsweredBy { get; set; }
        public string Participants { get; set; }

        public List<string> ErrorList;
        public bool CanProcess { get; set; }
        public IDictionary<string, object> Parameters { get; set; }

        #endregion

        #region Constructors

        public Step(int workflowInstanceId, int workflowId, State state)
        {
            this.WorkflowInstanceId = workflowInstanceId;
            this.WorkflowId = workflowId;
            this.State = state;

            this.ErrorList = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generate the step WorkflowId from a guid.  Used when a step is first created
        /// </summary>
        /// <returns>New StepId as string</returns>
        public string CreateStepId()
        {
            //Enforce.That(string.IsNullOrEmpty(this.StepId),
            //                "Step.CreateStepId - StepId has already been defined - " +
            //                this.StepId);

            this.StepId = Guid.NewGuid().ToString();

            return this.StepId;
        }

        /// <summary>
        /// Determine if a step has all the information needed to trigger
        /// the next state in a state machine
        /// </summary>
        /// <returns>True when valid</returns>
        public bool IsValidForWorkflowTransition()
        {

            return false;
            //return this.Enforce<Step>("Step", true)
            //            .When("AnsweredBy", Janga.Validation.Compare.NotEqual, string.Empty)
            //            .When("Answer", Janga.Validation.Compare.NotEqual, string.Empty)
            //            .When("State", Janga.Validation.Compare.NotEqual, string.Empty)
            //            .When("WorkflowInstanceId", Janga.Validation.Compare.NotEqual, string.Empty)
            //            .IsValid;
        }

        /// <summary>
        /// Determine if the user is authorized to provide an answer
        /// </summary>
        /// <returns></returns>
        public bool IsUserValidParticipant()
        {
            return false;
            //return this.Enforce<Step>("Step", true)
            //            .When("Participants", Janga.Validation.Compare.Contains, this.AnsweredBy)
            //            .IsValid;
        }

        #endregion
    }
}
