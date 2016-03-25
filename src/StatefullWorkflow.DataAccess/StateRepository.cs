using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateRepository : IRepository<State, int>
    {
        State GetCurrentState();

        void SetCurrentState(State state);
    }

    public class StateRepository : JsonRepository<State, int>, IStateRepository
    {
        public State CurrentState { get; set; }

        public StateRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
        }

        public StateRepository(IUnitOfWork unitOfWork, State state)
            : base(unitOfWork, GenerateId)
        {
            CurrentState = state;
        }

        protected static int GenerateId(Dictionary<int, State> entities)
        {
            int id = 1;
            while (entities.ContainsKey(id))
            {
                id++;
            }
            return id;
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
