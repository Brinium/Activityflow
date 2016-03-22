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

        public Dictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return Context.GetDataSet<TEntity, Tid>();
        }

        public bool TestConnectionCanOpen<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return Context.DataSetExists<TEntity, Tid>();
        }

        public void SaveChanges<TEntity, Tid>(Dictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct
        {
            Context.SaveDataSet<TEntity, Tid>(entities);
        }

        public void Dispose()
        {
        }
    }
}
