
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IWorkflowInstanceRepository : IRepository<WorkflowInstance, int>
    {
        State GetCurrentState(int instanceId);

        void SetCurrentState(int instanceId, State state);
    }

    public class WorkflowInstanceRepository : JsonRepository<WorkflowInstance, int>, IWorkflowInstanceRepository
    {
        protected static int GenerateId(IDictionary<int, WorkflowInstance> entities)
        {
            int id = 1;
            while (entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }

        public WorkflowInstanceRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
            StateRepo = new StateRepository(UnitOfWork);
        }

        private StateRepository StateRepo { get; set; }

        public State GetCurrentState(int instanceId)
        {
            var instance = Get(instanceId);
            return StateRepo.Get(instance.CurrentStateId);
        }

        public void SetCurrentState(int instanceId, State state)
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
