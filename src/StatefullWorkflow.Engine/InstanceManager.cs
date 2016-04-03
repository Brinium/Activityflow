using StatefullWorkflow.Entities;
using Stateless;
using StatefullWorkflow.DataAccess;
using StatefullWorkflow.Utilities;

namespace StatefullWorkflow.Engine
{
    public class InstanceManager
    {
        public string InstanceId { get; set; }
        public Workflow Workflow { get; set; }
        public StateMachine<State, string> StateMachine { get; set; }
        public IRepositoryHelper RepositoryHelper { get; set; }
        public IWorkflowInstanceRepository repo { get; set; }
        public InstanceStatePersistence StatePersistance { get; set; }


        public InstanceManager(WorkflowInstance instance, Workflow workflow, StateMachine<State, string> stateMachine, InstanceStatePersistence statePersistance, IRepositoryHelper repositoryHelper)
        {
            Enforce.ArgumentNotNull(instance, "instance");
            Enforce.ArgumentNotNull(workflow, "workflow");
            Enforce.ArgumentNotNull(stateMachine, "stateMachine");
            Enforce.ArgumentNotNull(statePersistance, "statePersistance");
            Enforce.ArgumentNotNull(repositoryHelper, "repositoryHelper");

            InstanceId = instance.Id;
            StatePersistance = statePersistance;
            Workflow = workflow;
            RepositoryHelper = repositoryHelper;
            StateMachine = stateMachine;
        }
    }
}
