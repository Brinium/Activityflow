using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateTransitionRepository : IRepository<StateTransition, int>
    {
    }

    public class StateTransitionRepository : JsonRepository<StateTransition, int>, IStateTransitionRepository
    {
        public StateTransitionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
        }

        protected static int GenerateId(IDictionary<int, StateTransition> entities)
        {
            int id = 1;
            while (entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }
    }
}
