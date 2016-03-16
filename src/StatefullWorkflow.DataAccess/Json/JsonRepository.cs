using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public static Dictionary<int, TEntity> Entities { get; set; }

        public JsonRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.GetDataSet<TEntity>();
        }

        public int Insert(TEntity entity)
        {
            if (entity == null) return -1;

            var newId = GenerateNewId();
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

        public int Update(TEntity entity)
        {
            if (entity == null) return -1;

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

        public TEntity Get(int id)
        {
            if(Entities.ContainsKey(id))
                return Entities[id];
            return null;
        }

        public void Delete(int id)
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
            if (result == null) return null;
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
        
        private int GenerateNewId()
        {
            int id = 1;
            while (Entities.ContainsKey(id))
            {
                id++;
            }
            return id;
        }
    }
}
