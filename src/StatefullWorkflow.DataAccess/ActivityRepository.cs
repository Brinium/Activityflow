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
        IList<Activity> GetByWorkflow(string workflowId);
    }

    public class ActivityRepository : JsonRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Activity> GetByWorkflow(string workflowId)
        {
            return Where(a => a.WorkflowId == workflowId).ToList();
        }

    }
}
