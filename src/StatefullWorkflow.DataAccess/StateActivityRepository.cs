using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateActivityRepository : IRepository<StateActivity>
    {
        IList<StateActivity> GetByWorkflow(string workflowId);
        void SetWorkflowStates(string workflowId, IList<StateActivity> stateActivities);
    }

    public class StateActivityRepository : JsonRepository<StateActivity>, IStateActivityRepository
    {
        public StateActivityRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<StateActivity> GetByWorkflow(string workflowId)
        {
            return Where(a => a.WorkflowId == workflowId).ToList();
        }

        public void SetWorkflowStates(string workflowId, IList<StateActivity> stateActivities)
        {
            var existing = GetByWorkflow(workflowId);

            foreach (var item in existing)
            {
                Delete(item.Id);
            }

            foreach (var item in stateActivities)
            {
                Insert(item);
            }
        }
    }
}
