using StatefullWorkflow.Entities;
using Stateless;
using StatefullWorkflow.DataAccess;

namespace StatefullWorkflow.Engine
{
    public class InstanceManager
    {
        public int InstanceId { get; set; }
        public Workflow Workflow { get; set; }
        public StateMachine<State, string> StateMachine { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public IWorkflowInstanceRepository repo { get; set; }
        public InstanceStatePersistence StatePersistance { get; set; }


        public InstanceManager(WorkflowInstance instance, Workflow workflow, StateMachine<State, string> stateMachine, InstanceStatePersistence statePersistance, IUnitOfWork unitOfWork)
        {
            InstanceId = instance.Id;
            StatePersistance = statePersistance;
            Workflow = workflow;
            UnitOfWork = unitOfWork;
            StateMachine = stateMachine;
        }
    }
}
