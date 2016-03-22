using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public interface IRepository<TEntity, Tid> where TEntity : Entity<Tid> where Tid : struct
    {
        IUnitOfWork UnitOfWork { get; set; }

        TEntity Get(Tid id);

        IQueryable<TEntity> All();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        void Delete(Tid id);

        Tid? Insert(TEntity entity);

        Tid? Update(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> expression);
    }
}
