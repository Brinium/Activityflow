
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IWorkflowInstanceRepository : IRepository<WorkflowInstance>
    {
        State GetCurrentState(string instanceId);

        void SetCurrentState(string instanceId, State state);
    }

    public class WorkflowInstanceRepository : JsonRepository<WorkflowInstance>, IWorkflowInstanceRepository
    {
        public WorkflowInstanceRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            StateRepo = new StateRepository(UnitOfWork);
        }

        private StateRepository StateRepo { get; set; }

        public State GetCurrentState(string instanceId)
        {
            var instance = Get(instanceId);
            return StateRepo.Get(instance.CurrentStateId);
        }

        public void SetCurrentState(string instanceId, State state)
        {
            var instance = Get(instanceId);
            if (instance != null)
            {
                instance.CurrentStateId = state.Id;
                Update(instance);
            }
        }
    }
}
