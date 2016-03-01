using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StatefullWorkflow.Configuration
{
    public class Workflow
    {
        public string WorkflowType { get; set; }
        public List<State> States { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<StateConfig> StateConfigs { get; set; }
        public List<Activity> Activities { get; set; }
        public List<StateActivity> StateActivities { get; set; }

        public Workflow() { }
    }
}
