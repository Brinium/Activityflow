using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatefullWorkflow.Entities;
using StatefullWorkflow.DataAccess.Exceptions;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonRepository<TEntity, Tid> : IRepository<TEntity, Tid> where TEntity : Entity<Tid> where Tid : struct
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public Dictionary<Tid, TEntity> Entities { get; set; }

        public Func<Dictionary<Tid, TEntity>, Tid> IdGenereator { get; set; }

        public JsonRepository(IUnitOfWork unitOfWork, Func<Dictionary<Tid, TEntity>, Tid> idGenerator)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.GetDataSet<TEntity, Tid>();
            IdGenereator = idGenerator;
        }

        public Tid? Insert(TEntity entity)
        {
            if (entity == null)
                return null;

            var newId = GenerateId();
            entity.Id = newId;

            if (!Entities.ContainsKey(newId))
            {
                Entities.Add(entity.Id, entity);
            }
            else
            {
                throw new DataAccessException();
            }
            return entity.Id;
        }

        public Tid? Update(TEntity entity)
        {
            if (entity == null)
                return null;

            if (Entities.ContainsKey(entity.Id))
            {
                Entities[entity.Id] = entity;
            }
            else
            {
                return Insert(entity);
            }
            return entity.Id;
        }

        public TEntity Get(Tid id)
        {
            if (Entities.ContainsKey(id))
                return Entities[id];
            return null;
        }

        public void Delete(Tid id)
        {
            if (Entities.ContainsKey(id))
                Entities.Remove(id);
        }

        public IQueryable<TEntity> All()
        {
            return Entities.Values.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return All().Where(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            var result = All().FirstOrDefault(expression);
            if (result == null)
                return null;
            return result;
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var result = Where(expression).ToList();
            foreach (var item in result)
            {
                Entities.Remove(item.Id);
            }
        }

        private Tid GenerateId()
        {
            return IdGenereator(Entities);
        }
    }
}
