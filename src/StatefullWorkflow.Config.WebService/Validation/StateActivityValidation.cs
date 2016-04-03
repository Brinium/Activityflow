using System;
using System.Linq;
using System.Collections.Generic;
using FluentValidation;
using StatefullWorkflow.Config.WebService.DataContracts;
using System.Web;

namespace StatefullWorkflow.Config.WebService.Validation
{
    public class StateActivityValidation : AbstractValidator<StateActivityDC>
    {
        public StateActivityValidation()
        {
            RuleFor(activity => activity.Id).NotEmpty();
            RuleFor(activity => activity.WorkflowId).NotEmpty().WithMessage("The State must be associated with a workflow");
            RuleFor(activity => activity.DisplayName).NotEmpty().WithMessage("Please specify a display name");
            RuleFor(activity => activity.AuthorisedRoles).NotNull().WithMessage("Please specify at least 1 role");
            RuleFor(activity => activity.AuthorisedRoles.Count).GreaterThan(0).WithMessage("Please specify at least 1 role");
        }
    }
}