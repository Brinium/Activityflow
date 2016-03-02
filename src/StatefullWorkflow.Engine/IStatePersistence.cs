using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Configuration;

namespace StatefullWorkflow.Engine
{
    public interface IStateRepository
    {
        State GetCurrentState();
        void SetCurrentState(State state);
    }
}
