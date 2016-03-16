using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IActivityRepository : IRepository<Activity>
    {
    }

    public class ActivityRepository : JsonRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
