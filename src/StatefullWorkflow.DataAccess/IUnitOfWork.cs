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

        IDictionary<Tid, TEntity> Set<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct;

        IDictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct;

        bool TestConnectionCanOpen<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct;

        void SaveChanges();

        void SaveChanges<TEntity, Tid>(IDictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct;

        void Dispose();
    }
}
