using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IWorkflowRepository : IRepository<Workflow, int>
    {
    }

    public class WorkflowRepository : JsonRepository<Workflow, int>, IWorkflowRepository
    {
        public WorkflowRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override int GenerateId()
        {
            int id = 1;
            while (Entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }
    }
}
