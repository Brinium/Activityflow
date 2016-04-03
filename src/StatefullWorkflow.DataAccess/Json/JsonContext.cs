using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StatefullWorkflow.DataAccess.IO;
using StatefullWorkflow.Entities;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace StatefullWorkflow.DataAccess.Json
{
    public class JsonContext
    {
        public IFileAccessor FileAccess { get; set; }
        public string ConnectionString { get; set; }
        public List<JsonConverter> Converters { get; set; }
        readonly IDictionary<string, object> _dataSets = new Dictionary<string, object>();
        public IDictionary<string, object> DataSets { get { return _dataSets; } }

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

        public IDictionary<string, TEntity> Set<TEntity>() where TEntity : Entity
        {
            var className = typeof(TEntity).Name;

            object result;
            if (!_dataSets.TryGetValue(className, out result))
            {
                result = GetDataSet<TEntity>();
                _dataSets.Add(className, result);
            }

            return (IDictionary<string, TEntity>)result;
        }

        public bool DataSetLoaded<TEntity>() where TEntity : Entity
        {
            var className = typeof(TEntity).Name;
            if (_dataSets.ContainsKey(className))
            {
                return true;
            }
            return false;
        }

        public bool DataSetExists<TEntity>() where TEntity : Entity
        {
            var exists = false;
            var task = Task.Run(async () => exists = await FileAccess.FileExists<TEntity>(ConnectionString));
            task.Wait();
            return exists;
        }
        
        public bool SaveDataSets()
        {
            var saved = _dataSets.Count == 0;
            foreach (var set in _dataSets)
            {
                var className = set.Key;
                var entities = set.Value;

                if (typeof(IDictionary).IsAssignableFrom(entities.GetType()))
                {
                    IDictionary idict = (IDictionary)entities;
                    var entitiesList = idict.Values;
                    var json = SerializeJsonEntityArray(entitiesList);

                    var task = Task.Run(async () => saved = await FileAccess.SaveToFile(ConnectionString, className, json));
                    task.Wait();
                }
            }
            return saved;
        }

        public bool SaveDataSet<TEntity>(IDictionary<string, TEntity> entities) where TEntity : Entity
        {
            var entitiesList = entities.Values.ToList();
            var json = SerializeJsonEntityArray(entitiesList);

            var saved = false;
            var task = Task.Run(async () => saved = await FileAccess.SaveToFile<TEntity>(ConnectionString, json));
            task.Wait();
            return saved;
        }

        public IDictionary<string, TEntity> GetDataSet<TEntity>() where TEntity : Entity
        {
            IDictionary<string, TEntity> entityDic = new Dictionary<string, TEntity>();
            if (!DataSetLoaded<TEntity>())
            {
                if (!DataSetExists<TEntity>())
                {
                    var created = false;
                    var createTask = Task.Run(async () => created = await FileAccess.SaveToFile<TEntity>(ConnectionString, "[]"));
                    createTask.Wait();
                }
                string json = string.Empty;

                var readTask = Task.Run(async () => json = await FileAccess.ReadFile<TEntity>(ConnectionString));
                readTask.Wait();

                var entities = DeserializeJsonEntityArray<TEntity>(json);
                foreach (var item in entities)
                {
                    if (!entityDic.ContainsKey(item.Id))
                    {
                        entityDic.Add(item.Id, item);
                    }
                }
            }
            else
            {
                entityDic = Set<TEntity>();
            }
            return entityDic;
        }

        public string SerializeJsonEntityArray(ICollection entities)
        {
            var json = string.Empty;
            if (Converters != null && Converters.Count > 0)
                json = JsonConvert.SerializeObject(entities, Converters.ToArray());
            else
                json = JsonConvert.SerializeObject(entities);
            return json;
        }

        public string SerializeJsonEntityArray<TEntity>(List<TEntity> entities)
        {
            var json = string.Empty;
            if (Converters != null && Converters.Count > 0)
                json = JsonConvert.SerializeObject(entities, Converters.ToArray());
            else
                json = JsonConvert.SerializeObject(entities);
            return json;
        }

        public ICollection<TEntity> DeserializeJsonEntityArray<TEntity>(string json) where TEntity : Entity
        {
            var entities = JsonConvert.DeserializeObject<TEntity[]>(json);
            return new List<TEntity>(entities);
        }
    }
}
