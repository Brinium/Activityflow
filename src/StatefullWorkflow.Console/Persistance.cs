using StatefullWorkflow.Engine;

namespace StatefullWorkFlow.Console
{
    public static class Persistence
    {
        public static InstanceManager CurrentInstanceManager { get; set; }

        static Persistence()
        {
        }
    }
}
