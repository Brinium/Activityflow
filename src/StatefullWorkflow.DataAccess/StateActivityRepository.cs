using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateActivityRepository : IRepository<StateActivity, int>
    {
    }

    public class StateActivityRepository : JsonRepository<StateActivity, int>, IStateActivityRepository
    {
        public StateActivityRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
        }
        
        protected static int GenerateId(Dictionary<int, StateActivity> entities)
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
