using System;
using StatefullWorkflow.Entities;
using System.Collections.Generic;

namespace StatefullWorkflow.Engine
{
    public class StepPipline
    {
        State CurrentStage { get; set; }

        List<Activity> Activities { get; set; }

        public int WorkflowInstanceId { get; set; }

        public string WorkflowId { get; set; }

        public string StepId { get; set; }

        public StepPipline()
        {
        }
    }
}

