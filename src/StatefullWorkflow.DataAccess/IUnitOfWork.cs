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

        IDictionary<string, TEntity> Set<TEntity>() where TEntity : Entity;

        IDictionary<string, TEntity> GetDataSet<TEntity>() where TEntity : Entity;

        bool TestConnectionCanOpen<TEntity>() where TEntity : Entity;

        void SaveChanges();

        void SaveChanges<TEntity>(IDictionary<string, TEntity> entities) where TEntity : Entity;

        void Dispose();
    }
}
