using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.Engine
{
    public interface IWorkflowStatePersistence
    {
        State GetCurrentState();
        void SetCurrentState(State state);
    }
}
