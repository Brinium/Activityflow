using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateTransitionRepository : IRepository<StateTransition>
    {
        IList<StateTransition> GetByWorkflow(string workflowId);
        void SetWorkflowStates(string workflowId, IList<StateTransition> stateTransition);
    }

    public class StateTransitionRepository : JsonRepository<StateTransition>, IStateTransitionRepository
    {
        public StateTransitionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<StateTransition> GetByWorkflow(string workflowId)
        {
            return Where(t => t.WorkflowId == workflowId).ToList();
        }

        public void SetWorkflowStates(string workflowId, IList<StateTransition> stateTransition)
        {
            var existing = GetByWorkflow(workflowId);

            foreach (var item in existing)
            {
                Delete(item.Id);
            }

            foreach (var item in stateTransition)
            {
                Insert(item);
            }
        }
    }
}
