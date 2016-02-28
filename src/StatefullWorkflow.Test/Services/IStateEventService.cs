using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stateless;

namespace ConfigurableStatelessMachine.Services
{
    public interface IStateEventService
    {
        void OnEntryStateAction(StateMachine<State, string>.Transition entryAction);
        void OnExitStateAction(StateMachine<State, string>.Transition exitAction);
    }
}
