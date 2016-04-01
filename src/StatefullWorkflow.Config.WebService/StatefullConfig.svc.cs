using StatefullWorkflow.Config.WebService.DataContracts;
using StatefullWorkflow.DataAccess;
using StatefullWorkflow.DataAccess.Json;
using StatefullWorkflow.Entities;
using StatefullWorkflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StatefullWorkflow.Config.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StatefullConfig : IStatefullConfig
    {
        private readonly string _connectionString = "H:\\Sam\\GitHub\\StatefullWorkflow\\src\\StatefullWorkflow.Config.WebService\\bin\\App_Data";
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public WorkflowDC GetWorkflow(int workflowId)
        {
            Enforce.ArgumentGreaterThanZero(workflowId, "workflowId");

            WorkflowDC workflowDC = null;

            try
            {
                var unitOfWork = new JsonUnitOfWork(_connectionString);
                var wfRepo = new WorkflowRepository(unitOfWork);
                var workflow = wfRepo.Get(workflowId);

                if (workflow != null)
                {
                    workflowDC = new WorkflowDC(workflow);

                    var stateRepo = new StateRepository(unitOfWork);
                    workflowDC.States = stateRepo.GetByWorkflow(workflowId);

                    var actRepo = new StateActivityRepository(unitOfWork);
                    workflowDC.Activities = actRepo.GetByWorkflow(workflowId);

                    var tranRepo = new StateTransitionRepository(unitOfWork);
                    workflowDC.Transitions = tranRepo.GetByWorkflow(workflowId);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
            return workflowDC;
        }
    }
}
