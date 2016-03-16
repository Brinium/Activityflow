using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class Workflow : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public List<State> States { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<WorkflowStateTransition> StateConfigs { get; set; }
        public List<Activity> Activities { get; set; }
        public List<WorkflowStateActivity> StateActivities { get; set; }

        public Workflow() { }
    }
}
