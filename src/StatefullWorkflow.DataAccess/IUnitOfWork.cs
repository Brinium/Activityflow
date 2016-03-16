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
        Dictionary<int, TEntity> GetDataSet<TEntity>() where TEntity : Entity;
        bool TestConnectionCanOpen<TEntity>() where TEntity : Entity;
        void SaveChanges<TEntity>(Dictionary<int, TEntity> entities) where TEntity : Entity;
        void Dispose();
    }
}
