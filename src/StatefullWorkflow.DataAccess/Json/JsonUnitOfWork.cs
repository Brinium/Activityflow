using System;
using System.Collections.Generic;
using StatefullWorkflow.Entities;

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

        public Dictionary<int, TEntity> GetDataSet<TEntity>() where TEntity : Entity
        {
            return Context.GetDataSet<TEntity>();
        }

        public bool TestConnectionCanOpen<TEntity>() where TEntity : Entity
        {
            return Context.DataSetExists<TEntity>();
        }

        public void SaveChanges<TEntity>(Dictionary<int, TEntity> entities) where TEntity : Entity
        {
            Context.SaveDataSet<TEntity>(entities);
        }

        public void Dispose()
        {
        }
    }
}
