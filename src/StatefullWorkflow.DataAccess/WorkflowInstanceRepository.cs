
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
        State GetCurrentState();

        void SetCurrentState(State state);
    }

    public class WorkflowInstanceRepository : JsonRepository<WorkflowInstance, int>, IWorkflowInstanceRepository
    {
        protected static int GenerateId(Dictionary<int, WorkflowInstance> entities)
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

        public State GetCurrentState(int workflowInstanceId)
        {
            var instance = Get(workflowInstanceId);
            return StateRepo.Get(instance.Id);
        }

        public void SetCurrentState(int workflowInstanceId, State state)
        {
            var instance = Get(workflowInstanceId);
            instance.CurrentStateId = state.Id;
            Update(instance);
        }
    }
}
