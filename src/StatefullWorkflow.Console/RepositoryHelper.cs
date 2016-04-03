using StatefullWorkflow.DataAccess;
using StatefullWorkflow.DataAccess.Json;

namespace StatefullWorkFlow.Console
{
    public class RepositoryHelper : IRepositoryHelper
    {
        private IUnitOfWork _unitOfWork;
        public string ConnectionString { get; set; }

        public RepositoryHelper(string connectionString)
        {
            ConnectionString = connectionString;
            _unitOfWork = new JsonUnitOfWork(ConnectionString);
        }

        public IUnitOfWork GetUnitOfWork()
        {
            if (_unitOfWork == null)
                _unitOfWork = new JsonUnitOfWork(ConnectionString);
            return _unitOfWork;
        }

        public IWorkflowRepository GetWorkflowRepository(IUnitOfWork unitOfWork)
        {
            return new WorkflowRepository(unitOfWork);
        }

        public IStateRepository GetStateRepository(IUnitOfWork unitOfWork)
        {
            return new StateRepository(unitOfWork);
        }

        public IStateActivityRepository GetStateActivityRepository(IUnitOfWork unitOfWork)
        {
            return new StateActivityRepository(unitOfWork);
        }

        public IStateTransitionRepository GetStateTransitionRepository(IUnitOfWork unitOfWork)
        {
            return new StateTransitionRepository(unitOfWork);
        }

        public IWorkflowInstanceRepository GetWorkflowInstanceRepository(IUnitOfWork unitOfWork)
        {
            return new WorkflowInstanceRepository(unitOfWork);
        }
    }
}
