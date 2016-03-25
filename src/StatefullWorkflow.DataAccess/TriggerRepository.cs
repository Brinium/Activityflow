using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface ITriggerRepository : IRepository<Trigger, int>
    {
    }

    public class TriggerRepository : JsonRepository<Trigger, int>, ITriggerRepository
    {
        public TriggerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
        }

        protected static int GenerateId(Dictionary<int, Trigger> entities)
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
