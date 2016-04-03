using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; set; }

        TEntity Get(string id);

        IQueryable<TEntity> All();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        void Delete(string id);

        string Insert(TEntity entity);

        string Update(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> expression);
    }
}
