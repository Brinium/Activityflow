using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public interface IUnitOfWork
    {
        string ConnectionString { get; set; }

        Dictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct;

        bool TestConnectionCanOpen<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct;

        void SaveChanges<TEntity, Tid>(Dictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct;

        void Dispose();
    }
}
