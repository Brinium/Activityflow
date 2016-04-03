using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateRepository : IRepository<State>
    {
        IList<State> GetByWorkflow(string workflowId);
        void SetWorkflowStates(string workflowId, IList<State> states);
    }

    public class StateRepository : JsonRepository<State>, IStateRepository
    {
        public StateRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<State> GetByWorkflow(string workflowId)
        {
            return Where(s => s.WorkflowId == workflowId).ToList();
        }

        public void SetWorkflowStates(string workflowId, IList<State> states)
        {
            var existing = GetByWorkflow(workflowId);

            foreach (var item in existing)
            {
                Delete(item.Id);
            }

            foreach (var item in states)
            {
                Insert(item);
            }
        }
    }
}
