using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public partial interface IWorkflowRepository : IRepository<Workflow>
    {
    }

    public class WorkflowRepository : JsonRepository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
