using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StatefullWorkflow.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; set; }

        TEntity Get(int id);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        void Delete(int id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> expression);
    }
}
