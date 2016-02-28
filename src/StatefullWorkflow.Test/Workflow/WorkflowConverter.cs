using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConfigurableStatelessMachine.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConfigurableStatelessMachine
{
    public class WorkflowConverter : CustomCreationConverter<Workflow>
    {
        public override Workflow Create(Type objectType)
        {
            return new Workflow();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = Create(objectType);// (State)base.ReadJson(reader, objectType, existingValue, serializer);
            //if (reader.TokenType == JsonToken.Null)
            //    return null;

            target = (Workflow)base.ReadJson(reader, objectType, existingValue, serializer);
            
            return target;
        }

        private Action<State> GetHandlerByName(string name)
        {
            var names = name.Split(',');
            Action<State> action = null;

            try
            {
                if (names.Length == 2)
                {
                    Type type = Type.GetType(names[0], true);
                    if (type != null && type.GetInterfaces().Contains(typeof(IStateEventService)) && (names[1] == "OnEntryStateAction" || names[1] == "OnExitStateAction"))
                    {
                        object newInstance = Activator.CreateInstance(type);
                        MethodInfo method = type.GetMethod(names[1], BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                        // Insert appropriate check for method == null here
                        action = (Action<State>)Delegate.CreateDelegate(typeof(Action<State>), newInstance, method);
                    }
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return action;
        }
    }
}
