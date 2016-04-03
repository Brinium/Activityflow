using System;
using System.Linq;
using System.Collections.Generic;
using FluentValidation;
using StatefullWorkflow.Config.WebService.DataContracts;
using System.Web;

namespace StatefullWorkflow.Config.WebService.Validation
{
    public class WorkflowValidation : AbstractValidator<WorkflowDC>
    {
        public WorkflowValidation()
        {
            RuleFor(workflow => workflow.Id).NotEmpty().WithMessage("Please specify an ID");
            RuleFor(workflow => workflow.DisplayName).NotEmpty().WithMessage("Please specify a display name");
            RuleFor(workflow => workflow.StartState).NotEmpty().WithMessage("Please specify at least 1 state");

            RuleFor(workflow => workflow.States).NotNull().WithMessage("Please specify at least 1 state")
                .SetCollectionValidator(new StateValidation());
            RuleFor(workflow => workflow.States.Count).GreaterThan(0).WithMessage("Please specify at least 1 state");
            
            RuleFor(workflow => workflow.Activities).NotNull().WithMessage("Please specify at least 1 state")
                .SetCollectionValidator(new StateActivityValidation());

            RuleFor(workflow => workflow).Must(StartStateExists).WithMessage("Please start state must exist")
                                         .Must(ActivityStateExits).WithMessage("The activity must have a state ID and workflow ID that exits")
                                         .Must(TransitionStateExits).WithMessage("The activity must have a workflow ID  and start/end states ID that exits");
        }

        private bool StartStateExists(WorkflowDC workflow)
        {
            foreach (var item in workflow.States)
            {
                if (workflow.StartState == item.Id)
                    return true;
            }
            return false;
        }

        private bool ActivityStateExits(WorkflowDC workflow)
        {
            foreach (var item in workflow.Activities)
            {
                if (workflow.Id != item.WorkflowId)
                    return false;
                if (!workflow.States.Select(s => s.Id).Any(s => s == item.StateId))
                    return false;
            }
            return true;
        }

        private bool TransitionStateExits(WorkflowDC workflow)
        {
            foreach (var item in workflow.Transitions)
            {
                if (!workflow.States.Select(s => s.Id).Any(s => s == item.StateId))
                    return false;
                if (!workflow.States.Select(s => s.Id).Any(s => s == item.TargetStateId))
                    return false;
            }
            return true;
        }
    }
}