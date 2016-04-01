using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IStateRepository : IRepository<State, int>
    {
        IList<State> GetByWorkflow(int workflowId);
    }

    public class StateRepository : JsonRepository<State, int>, IStateRepository
    {
        public StateRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, GenerateId)
        {
        }

        protected static int GenerateId(IDictionary<int, State> entities)
        {
            int id = 1;
            while (entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }

        public IList<State> GetByWorkflow(int workflowId)
        {
            return Where(s => s.WorkflowId == workflowId).ToList();
        }
    }
}
