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
using Stateless;

namespace StatefullWorkflow.DataAccess.JSON
{
    public class WorkflowStateConverter : CustomCreationConverter<WorkflowState>
    {
        public override WorkflowState Create(Type objectType)
        {
            return new WorkflowState();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = Create(objectType);

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
                    target.OnEntryStateAction = ReflectionHelper.GetHandlerByName<StateMachine<State, string>.Transition>((string)prop.Value);
                }
                else if (prop.Key == "OnExitStateAction")
                {
                    target.OnExitStateAction = ReflectionHelper.GetHandlerByName<StateMachine<State, string>.Transition>((string)prop.Value);
                }
            }

            return target;
        }
    }
}
