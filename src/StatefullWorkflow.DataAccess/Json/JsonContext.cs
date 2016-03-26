using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StatefullWorkflow.DataAccess.IO;
using StatefullWorkflow.Entities;
using System.Threading.Tasks;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonContext
    {
        public IFileAccessor FileAccess { get; set; }

        public string ConnectionString { get; set; }

        public List<JsonConverter> Converters { get; set; }

        public JsonContext()
        {
            FileAccess = new FileAccessor();
            Converters = new List<JsonConverter>();
        }

        public JsonContext(string connectionString)
        {
            FileAccess = new FileAccessor();
            ConnectionString = connectionString;
            Converters = new List<JsonConverter>();
        }

        public JsonContext(string connectionString, List<JsonConverter> converters)
        {
            FileAccess = new FileAccessor();
            ConnectionString = connectionString;
            Converters = converters;
        }

        public bool DataSetExists<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            var exists = false;
            var task = Task.Run(async () => exists = await FileAccess.FileExists<TEntity, Tid>(ConnectionString));
            task.Wait();
            return exists;
        }

        public bool SaveDataSet<TEntity, Tid>(Dictionary<Tid, TEntity> entities) where TEntity : Entity<Tid> where Tid : struct
        {
            var entitiesList = entities.Values.ToList();
            var json = SerializeJsonEntityArray<TEntity, Tid>(entitiesList);
            var saved = false;
            var task = Task.Run(async () => saved = await FileAccess.SaveToFile<TEntity, Tid>(ConnectionString, json));
            task.Wait();
            return saved;
        }

        public Dictionary<Tid, TEntity> GetDataSet<TEntity, Tid>() where TEntity : Entity<Tid> where Tid : struct
        {
            string json = string.Empty;
            if(!DataSetExists<TEntity, Tid>())
            {
                var created = false;
                var createTask = Task.Run(async () => created = await FileAccess.SaveToFile<TEntity, Tid>(ConnectionString, "[]"));
                createTask.Wait();
            }
            var readTask = Task.Run(async () => json = await FileAccess.ReadFile<TEntity, Tid>(ConnectionString));
            readTask.Wait();

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
            var json = string.Empty;
            if(Converters != null && Converters.Count > 0)
                json = JsonConvert.SerializeObject(entities, Converters.ToArray());
            else
                json = JsonConvert.SerializeObject(entities);
            return json;
        }

        public ICollection<TEntity> DeserializeJsonEntityArray<TEntity, Tid>(string json) where TEntity : Entity<Tid> where Tid : struct
        {
            var entities = JsonConvert.DeserializeObject<TEntity[]>(json);
            return new List<TEntity>(entities);
        }
    }
}
