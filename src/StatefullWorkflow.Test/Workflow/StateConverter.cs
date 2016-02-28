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
using Stateless;

namespace ConfigurableStatelessMachine
{
    public class StateConverter : CustomCreationConverter<State>
    {
        public override State Create(Type objectType)
        {
            return new State();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = Create(objectType);// (State)base.ReadJson(reader, objectType, existingValue, serializer);
            //if (reader.TokenType == JsonToken.Null)
            //    return null;

            //// Load JObject from stream
            JObject jObject = JObject.Load(reader);

            foreach (var prop in jObject)
            {

                if (prop.Key == "Name")
                {
                    target.Name = (string)prop.Value;
                }
                else if (prop.Key == "DisplayName")
                {
                    target.DisplayName = (string)prop.Value;
                }
                else if (prop.Key == "InitialState")
                {
                    target.InitialState = (bool)prop.Value;
                }
                else if (prop.Key == "OnEntryStateAction")
                {
                    target.OnEntryStateAction = GetHandlerByName((string)prop.Value);
                }
                else if (prop.Key == "OnExitStateAction")
                {
                    target.OnExitStateAction = GetHandlerByName((string)prop.Value);
                }
            }
            //// Create target object based on JObject
            //State target = Create(objectType);

            ////Create a new reader for this jObject, and set all properties to match the original reader.
            //JsonReader jObjectReader = jObject.CreateReader();
            //jObjectReader.Culture = reader.Culture;
            //jObjectReader.DateParseHandling = reader.DateParseHandling;
            //jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            //jObjectReader.FloatParseHandling = reader.FloatParseHandling;

            //// Populate the object properties
            //serializer.Populate(reader, target);

            return target;
        }

        private Action<StateMachine<State, string>.Transition> GetHandlerByName(string name)
        {
            var names = name.Split(',');
            Action<StateMachine<State, string>.Transition> action = null;

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
                        action = (Action<StateMachine<State, string>.Transition>)Delegate.CreateDelegate(typeof(Action<StateMachine<State, string>.Transition>), newInstance, method);
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
