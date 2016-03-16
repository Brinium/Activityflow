using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface ITriggerRepository : IRepository<Trigger>
    {
    }

    public class TriggerRepository : JsonRepository<Trigger>, ITriggerRepository
    {
        public TriggerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
