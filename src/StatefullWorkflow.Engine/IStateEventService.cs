using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatefullWorkflow.Entities;
using Stateless;

namespace StatefullWorkflow.Engine
{
    public interface IStateEventService
    {
        void OnEntryStateAction(StateMachine<State, string>.Transition entryAction);
        void OnExitStateAction(StateMachine<State, string>.Transition exitAction);
    }
}
