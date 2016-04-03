using FluentValidation.Results;
using StatefullWorkflow.Config.WebService.DataContracts;
using StatefullWorkflow.Config.WebService.Validation;
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

        public WorkflowDC GetWorkflow(string workflowId)
        {
            Enforce.ArgumentGreaterThanZero(workflowId, "workflowId");

            IRepositoryHelper repoHelper = new RepositoryHelper(_connectionString);

            WorkflowDC workflowDC = null;

            try
            {
                var wfRepo = repoHelper.GetWorkflowRepository(repoHelper.GetUnitOfWork());
                var workflow = wfRepo.Get(workflowId);

                if (workflow != null)
                {
                    workflowDC = new WorkflowDC(workflow);

                    var stateRepo = new StateRepository(repoHelper.GetUnitOfWork());
                    workflowDC.States = stateRepo.GetByWorkflow(workflowId).ToDataContractList();

                    var actRepo = new StateActivityRepository(repoHelper.GetUnitOfWork());
                    workflowDC.Activities = actRepo.GetByWorkflow(workflowId).ToDataContractList();

                    var tranRepo = new StateTransitionRepository(repoHelper.GetUnitOfWork());
                    workflowDC.Transitions = tranRepo.GetByWorkflow(workflowId).ToDataContractList();

                    repoHelper.GetUnitOfWork().SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
            return workflowDC;
        }

        public bool UpdateWorkflow(WorkflowDC workflow)
        {
            Enforce.ArgumentNotNull(workflow, "workflow");
            Enforce.ArgumentNotNull(workflow.Id, "workflow.Id");
            Enforce.ArgumentNotNull(workflow.StartState, "workflow.StartState");
            Enforce.ArgumentNotNull(workflow.DisplayName, "workflow.DisplayName");
            Enforce.ArgumentGreaterThanZero(workflow.States.Count, "workflow.States");

            var validator = new WorkflowValidation();
            ValidationResult results = validator.Validate(workflow);

            IRepositoryHelper repoHelper = new RepositoryHelper(_connectionString);

            try
            {
                var unitOfWork = new JsonUnitOfWork(_connectionString);
                var wfRepo = new WorkflowRepository(unitOfWork);
                var workflowUpdated = wfRepo.Update(workflow.GetWorkflow());

                var stateRepo = new StateRepository(unitOfWork);
                stateRepo.SetWorkflowStates(workflow.Id, workflow.States.ToRepoList());

                var actRepo = new StateActivityRepository(unitOfWork);
                actRepo.SetWorkflowStates(workflow.Id, workflow.Activities.ToRepoList());

                var tranRepo = new StateTransitionRepository(unitOfWork);
                tranRepo.SetWorkflowStates(workflow.Id, workflow.Transitions.ToRepoList());

                repoHelper.GetUnitOfWork().SaveChanges();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
            return true;
        }

        public bool InsertWorkflow(WorkflowDC workflow)
        {
            Enforce.ArgumentNotNull(workflow, "workflow");
            Enforce.ArgumentNotNull(workflow.Id, "workflow.Id");
            Enforce.ArgumentNotNull(workflow.StartState, "workflow.StartState");
            Enforce.ArgumentNotNull(workflow.DisplayName, "workflow.DisplayName");
            Enforce.ArgumentGreaterThanZero(workflow.States.Count, "workflow.States");

            var validator = new WorkflowValidation();
            ValidationResult results = validator.Validate(workflow);

            IRepositoryHelper repoHelper = new RepositoryHelper(_connectionString);

            try
            {
                var unitOfWork = repoHelper.GetUnitOfWork();
                var wfRepo = repoHelper.GetWorkflowRepository(unitOfWork);
                var workflowUpdated = wfRepo.Insert(workflow.GetWorkflow());

                var stateRepo = repoHelper.GetStateRepository(unitOfWork);
                stateRepo.SetWorkflowStates(workflow.Id, workflow.States.ToRepoList());

                var actRepo = repoHelper.GetStateActivityRepository(unitOfWork);
                actRepo.SetWorkflowStates(workflow.Id, workflow.Activities.ToRepoList());

                var tranRepo = repoHelper.GetStateTransitionRepository(unitOfWork);
                tranRepo.SetWorkflowStates(workflow.Id, workflow.Transitions.ToRepoList());

                repoHelper.GetUnitOfWork().SaveChanges();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
            return true;
        }
    }
}
