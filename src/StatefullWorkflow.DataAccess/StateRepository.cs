using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateRepository : IRepository<State>
    {
        State GetCurrentState();
        void SetCurrentState(State state);
    }

    public class StateRepository : JsonRepository<State>, IStateRepository
    {
        public State CurrentState { get; set; }

        public StateRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public StateRepository(IUnitOfWork unitOfWork, State state)
            : base(unitOfWork)
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
