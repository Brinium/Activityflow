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

        public IDictionary<string, TEntity> Set<TEntity>() where TEntity : Entity
        {
            return Context.Set<TEntity>();
        }

        public IDictionary<string, TEntity> GetDataSet<TEntity>() where TEntity : Entity
        {
            return Context.GetDataSet<TEntity>();
        }

        public bool TestConnectionCanOpen<TEntity>() where TEntity : Entity
        {
            return Context.DataSetExists<TEntity>();
        }

        public void SaveChanges()
        {
            Context.SaveDataSets();
        }

        public void SaveChanges<TEntity>(IDictionary<string, TEntity> entities) where TEntity : Entity
        {
            Context.SaveDataSet(entities);
        }

        public void Dispose()
        {
        }
    }
}
