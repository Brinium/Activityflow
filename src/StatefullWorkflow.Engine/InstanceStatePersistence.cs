using StatefullWorkflow.DataAccess;
using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Engine
{
    public class InstanceStatePersistence
    {
        public int InstanceId { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public InstanceStatePersistence(int instanceId, IUnitOfWork unitOfWork)
        {
            InstanceId = instanceId;
            UnitOfWork = unitOfWork;
        }

        public State GetCurrentState()
        {
            var repo = new WorkflowInstanceRepository(UnitOfWork);
            return repo.GetCurrentState(InstanceId);
        }

        public void SetCurrentState(State state)
        {
            var repo = new WorkflowInstanceRepository(UnitOfWork);
            repo.SetCurrentState(InstanceId, state);
            repo.SaveChanges();
        }
    }
}
