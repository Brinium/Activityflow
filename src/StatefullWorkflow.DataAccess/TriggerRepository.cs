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
            : base(unitOfWork)
        {
        }

        protected override int GenerateId()
        {
            int id = 1;
            while (Entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }
    }
}
