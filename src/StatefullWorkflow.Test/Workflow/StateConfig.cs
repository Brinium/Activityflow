using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurableStatelessMachine
{
    public class StateConfig
    {
        public string State { get; set; }
        public string Trigger { get; set; }
        public string TargetState { get; set; }

        public StateConfig() { }
    }
}
