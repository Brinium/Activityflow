using System;
using System.Linq;
using System.Collections.Generic;
using FluentValidation;
using StatefullWorkflow.Config.WebService.DataContracts;
using System.Web;

namespace StatefullWorkflow.Config.WebService.Validation
{
    public class StateTransitionValidation : AbstractValidator<StateTransitionDC>
    {
        public StateTransitionValidation()
        {
            RuleFor(transition => transition.Id).NotEmpty();
            RuleFor(transition => transition.WorkflowId).NotEmpty().WithMessage("The State must be associated with a workflow");
            RuleFor(transition => transition.DisplayName).NotEmpty().WithMessage("Please specify a display name");
            RuleFor(transition => transition.Trigger).NotEmpty().WithMessage("Please specify a trigger");
            RuleFor(transition => transition.StateId).NotEmpty().WithMessage("Please specify a starting state");
            RuleFor(transition => transition.TargetStateId).NotEmpty().WithMessage("Please specify a ending state");
        }
    }
}