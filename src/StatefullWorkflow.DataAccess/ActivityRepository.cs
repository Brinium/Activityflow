using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IActivityRepository : IRepository<Activity, int>
    {
    }

    public class ActivityRepository : JsonRepository<Activity, int>, IActivityRepository
    {
        public ActivityRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override int GenerateId()
        {
            int id = 1;
            while (this.Entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }
    }
}
