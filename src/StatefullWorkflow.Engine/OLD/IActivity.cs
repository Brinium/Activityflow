using System;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.Engine
{
    public interface IActivity
    {
        Activity Activity { get; set; }

        State State { get; set; }

        Func<bool> TestIsComplete { get; set; }

        Func<bool> Action { get; set; }
    }
}

