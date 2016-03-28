using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.Tests
{
    public class TestEntityTwo : Entity<int>
    {
        public string FieldA { get; set; }

        public int FieldB { get; set; }

        public string FieldC { get; set; }

        public bool FieldD { get; set; }
    }
}
