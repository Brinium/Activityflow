using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using StatefullWorkflow.Entities;
using StatefullWorkflow.Utilities;

namespace StatefullWorkflow.DataAccess.Json
{
    public class StateConverter : CustomCreationConverter<State>
    {
        public override State Create(Type objectType)
        {
            return new State();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = Create(objectType);

            //// Load JObject from stream
            JObject jObject = JObject.Load(reader);

            foreach (var prop in jObject)
            {

                if (prop.Key == "DisplayName")
                {
                    target.DisplayName = (string)prop.Value;
                }
                else if (prop.Key == "WorkflowId")
                {
                    target.WorkflowId = (string)prop.Value;
                }
                else if (prop.Key == "OnEntryStateAction")
                {
                    target.OnEntryStateAction = (string)prop.Value; //ReflectionHelper.GetHandlerByName<StateMachine<State, string>.Transition>((string)prop.Value);
                }
                else if (prop.Key == "OnExitStateAction")
                {
                    target.OnExitStateAction = (string)prop.Value; //ReflectionHelper.GetHandlerByName<StateMachine<State, string>.Transition>((string)prop.Value);
                }
            }

            return target;
        }
    }
}
