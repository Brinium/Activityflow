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

        public bool DataSetExists<TEntity>() where TEntity : Entity
        {
            return FileAccess.FileExists<TEntity>(ConnectionString);
        }

        public bool SaveDataSet<TEntity>(Dictionary<int, TEntity> entities) where TEntity : Entity
        {
            var entitiesList = entities.Values.ToList();
            var json = SerializeJsonEntityArray<TEntity>(entitiesList);
            return FileAccess.SaveToFile<TEntity>(ConnectionString, json);
        }

        public Dictionary<int, TEntity> GetDataSet<TEntity>() where TEntity : Entity
        {
            string json = FileAccess.ReadFile<TEntity>(ConnectionString);

            var entities = DeserializeJsonEntityArray<TEntity>(json);
            var entityDic = new Dictionary<int, TEntity>();
            foreach (var item in entities)
            {
                if (!entityDic.ContainsKey(item.Id))
                {
                    entityDic.Add(item.Id, item);
                }
            }
            return entityDic;
        }

        public string SerializeJsonEntityArray<TEntity>(List<TEntity> entities) where TEntity : Entity
        {
            var json = JsonConvert.SerializeObject(entities);
            return json;
        }

        public ICollection<TEntity> DeserializeJsonEntityArray<TEntity>(string json) where TEntity : Entity
        {
            var entities = JsonConvert.DeserializeObject<TEntity[]>(json);
            return new List<TEntity>(entities);
        }
    }
}
