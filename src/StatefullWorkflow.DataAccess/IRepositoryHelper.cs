using StatefullWorkflow.DataAccess;

namespace StatefullWorkflow.DataAccess
{
    public interface IRepositoryHelper
    {
        IUnitOfWork GetUnitOfWork();

        IWorkflowRepository GetWorkflowRepository(IUnitOfWork unitOfWork);

        IStateRepository GetStateRepository(IUnitOfWork unitOfWork);

        IStateActivityRepository GetStateActivityRepository(IUnitOfWork unitOfWork);

        IStateTransitionRepository GetStateTransitionRepository(IUnitOfWork unitOfWork);
        
        IWorkflowInstanceRepository GetWorkflowInstanceRepository(IUnitOfWork unitOfWork);
    }
}