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
using StatefullWorkflow.Utilities;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public IDictionary<string, TEntity> Entities { get; set; }

        public JsonRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.Set<TEntity>();
        }

        public string Insert(TEntity entity)
        {
            Enforce.ArgumentNotNull(entity, "entity");

            if (string.IsNullOrWhiteSpace(entity.Id) || Entities.ContainsKey(entity.Id))
            {
                entity.Id = GenerateNewId();
            }

            if (!Entities.ContainsKey(entity.Id))
            {
                Entities.Add(entity.Id, entity);
            }
            else
            {
                throw new DataAccessException("Cannot insert an entity without an ID");
            }
            return entity.Id;
        }

        public string Update(TEntity entity)
        {
            Enforce.ArgumentNotNull(entity, "entity");

            if (!string.IsNullOrWhiteSpace(entity.Id) && Entities.ContainsKey(entity.Id))
            {
                Entities[entity.Id] = entity;
            }
            else
            {
                return Insert(entity);
            }
            return entity.Id;
        }

        public TEntity Get(string id)
        {
            Enforce.ArgumentNotNull(id, "id");

            if (Entities.ContainsKey(id))
                return Entities[id];
            return null;
        }

        public void Delete(string id)
        {
            Enforce.ArgumentNotNull(id, "id");

            if (Entities.ContainsKey(id))
                Entities.Remove(id);
        }

        public IQueryable<TEntity> All()
        {
            return Entities.Values.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            Enforce.ArgumentNotNull(expression, "expression");

            return All().Where(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            Enforce.ArgumentNotNull(expression, "expression");

            var result = All().FirstOrDefault(expression);
            if (result == null)
                return null;
            return result;
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            Enforce.ArgumentNotNull(expression, "expression");

            var result = Where(expression).ToList();
            foreach (var item in result)
            {
                Entities.Remove(item.Id);
            }
        }

        protected string GenerateNewId()
        {
            var id = Guid.NewGuid().ToString();
            while (FirstOrDefault(e => e.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
    }
}
