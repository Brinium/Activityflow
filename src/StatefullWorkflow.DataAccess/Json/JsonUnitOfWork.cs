using System;
using System.Collections.Generic;
using StatefullWorkflow.Entities;
using System.Threading.Tasks;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonUnitOfWork : IUnitOfWork
    {
        public JsonContext Context { get; set; }

        public string ConnectionString
        {
            get { return Context.ConnectionString; }
            set { Context.ConnectionString = value; }
        }

        public JsonUnitOfWork(string connectionString = null)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                Context = new JsonContext();
            else
                Context = new JsonContext(connectionString);
        }

        public IDictionary<Tid, TEntity> Set<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return Context.Set<TEntity, Tid>();
        }

        public IDictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return Context.GetDataSet<TEntity, Tid>();
        }

        public bool TestConnectionCanOpen<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return Context.DataSetExists<TEntity, Tid>();
        }

        public void SaveChanges()
        {
            Context.SaveDataSets();
        }

        public void SaveChanges<TEntity, Tid>(IDictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct
        {
            Context.SaveDataSet<TEntity, Tid>(entities);
        }

        public void Dispose()
        {
        }
    }
}
