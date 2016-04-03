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
        public string InstanceId { get; set; }
        public IRepositoryHelper RepoHelper { get; set; }

        public InstanceStatePersistence(string instanceId, IRepositoryHelper repoHelper)
        {
            InstanceId = instanceId;
            RepoHelper = repoHelper;
        }

        public State GetCurrentState()
        {
            var repo = RepoHelper.GetWorkflowInstanceRepository(RepoHelper.GetUnitOfWork());
            return repo.GetCurrentState(InstanceId);
        }

        public void SetCurrentState(State state)
        {
            var unitOfWork = RepoHelper.GetUnitOfWork();
            var repo = RepoHelper.GetWorkflowInstanceRepository(unitOfWork);
            repo.SetCurrentState(InstanceId, state);
            unitOfWork.SaveChanges();
        }
    }
}
