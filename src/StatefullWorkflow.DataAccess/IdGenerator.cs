using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.DataAccess
{
    internal static class IdGenerator
    {
        //public static int GenerateInt32Id<TEntity>(IRepository<TEntity> repository) where TEntity : Entity
        //{
        //    int id = 1;
        //    while (repository.FirstOrDefault(e => e.Id == id) != null)
        //    {
        //        id++;
        //    }
        //    return id;
        //}

        public static string GenerateStringId<TEntity>(IRepository<TEntity> repository) where TEntity : Entity
        {
            var id = Guid.NewGuid().ToString();
            while (repository.FirstOrDefault(e => e.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
    }
}
