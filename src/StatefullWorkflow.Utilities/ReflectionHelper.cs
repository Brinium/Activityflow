using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Utilities
{
    public class ReflectionHelper
    {
        public static Action<T> GetHandlerByName<T>(string name) where T : class
        {
            var names = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Action<T> action = null;

            try
            {
                if (names.Length == 3)
                {
                    //var assembly = Assembly.Load(name[0]);
                    //if (assembly != null)
                    //{
                    //Type type = assembly.GetType(names[0], true);
                    Type type = Type.GetType(names[1] + "," + names[0], true);
                    if (type != null)
                    {
                        object newInstance = Activator.CreateInstance(type);
                        MethodInfo method = type.GetMethod(names[2], BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                        action = (Action<T>)method.CreateDelegate(typeof(Action<T>), newInstance);
                        // Insert appropriate check for method == null here
                        //action = (Action<T>)MethodInfo.CreateDelegate(typeof(Action<T>), newInstance, method);
                    }
                    //}
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
