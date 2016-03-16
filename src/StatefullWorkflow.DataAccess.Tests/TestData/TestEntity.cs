using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.Test
{
    public class TestEntity : Entity
    {
        public string FieldA { get; set; }
        public int FieldB { get; set; }
        public string FieldC { get; set; }
        public bool FieldD { get; set; }
    }
}
