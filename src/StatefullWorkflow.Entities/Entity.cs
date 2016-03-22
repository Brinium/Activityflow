using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatefullWorkflow.Entities
{
    public class Entity<Tid> where Tid : struct
    {
        public Tid Id { get; set; }
    }
}
