using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stateless;

namespace ConfigurableStatelessMachine
{
    public static class Persistance
    {
        public static Workflow CurrentWorkflow { get; set; }
        public static StateMachine<State, string> CurrentStateMachine { get; set; }

        public static State CurrentState { get; private set; }

        static Persistance()
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
