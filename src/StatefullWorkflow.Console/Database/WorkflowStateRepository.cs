using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;
using Stateless;
using StatefullWorkFlow.Test.Database;
using StatefullWorkflow.Entities;

namespace StatefullWorkFlow.Test
{
    public class WorkflowStateRepository : IWorkflowStatePersistence
    {
        public static State CurrentState { get; set; }

        public WorkflowStateRepository()
        {
        }

        public WorkflowStateRepository(State state)
        {
            CurrentState = state;
        }

        public State GetCurrentState()
        {
            return CurrentState;
        }

        public void SetCurrentState(State state)
        {
            CurrentState = state;
        }
    }
}
