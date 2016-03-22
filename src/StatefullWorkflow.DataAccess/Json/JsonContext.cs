using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StatefullWorkflow.DataAccess.IO;
using StatefullWorkflow.Entities;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonContext
    {
        public IFileAccessor FileAccess { get; set; }

        public string ConnectionString { get; set; }

        public JsonContext()
        {
            FileAccess = new FileAccessor();
        }

        public JsonContext(string connectionString)
        {
            FileAccess = new FileAccessor();
            ConnectionString = connectionString;
        }

        public bool DataSetExists<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            return await FileAccess.FileExists<TEntity, Tid>(ConnectionString);
        }

        public bool SaveDataSet<TEntity, Tid>(Dictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct
        {
            var entitiesList = entities.Values.ToList();
            var json = SerializeJsonEntityArray<TEntity, Tid>(entitiesList);
            return await FileAccess.SaveToFile<TEntity, Tid>(ConnectionString, json);
        }

        public Dictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            string json = await FileAccess.ReadFile<TEntity, Tid>(ConnectionString);

            var entities = DeserializeJsonEntityArray<TEntity, Tid>(json);
            var entityDic = new Dictionary<Tid, TEntity>();
            foreach (var item in entities)
            {
                if (!entityDic.ContainsKey(item.Id))
                {
                    entityDic.Add(item.Id, item);
                }
            }
            return entityDic;
        }

        public string SerializeJsonEntityArray<TEntity, Tid>(List<TEntity> entities) where TEntity : Entity<Tid> where Tid : struct
        {
            var json = JsonConvert.SerializeObject(entities);
            return json;
        }

        public ICollection<TEntity> DeserializeJsonEntityArray<TEntity, Tid>(string json) where TEntity : Entity<Tid> where Tid : struct
        {
            var entities = JsonConvert.DeserializeObject<TEntity[]>(json);
            return new List<TEntity>(entities);
        }
    }
}
