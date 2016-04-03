using FluentValidation;
using StatefullWorkflow.Config.WebService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatefullWorkflow.Config.WebService.Validation
{
    public class StateValidation : AbstractValidator<StateDC>
    {
        public StateValidation()
        {
            RuleFor(state => state.Id).NotEmpty();
            RuleFor(state => state.WorkflowId).NotEmpty().WithMessage("The State must be associated with a workflow");
            RuleFor(state => state.DisplayName).NotEmpty().WithMessage("Please specify a display name");
        }
    }
}