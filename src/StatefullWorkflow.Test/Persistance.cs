using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Configuration;
using StatefullWorkflow.Engine;
using Stateless;

namespace StatefullWorkFlow.Test
{
    public static class Persistence
    {
        public static Workflow CurrentWorkflow { get; set; }
        public static StateMachine<State, string> CurrentStateMachine { get; set; }

        public static State CurrentState { get; private set; }

        static Persistence()
        {

        }

        public static State GetCurrentState()
        {
            return CurrentState;
        }

        public static void SetCurrentState(State state)
        {
            CurrentState = state;
        }
    }
}
