using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task2
{
    public class SimpleBinder
    {
        private SimpleBinder() { }

        private static SimpleBinder _instance;

        public static SimpleBinder Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new SimpleBinder();
                }

                return _instance;
            }
        }

        public T Bind<T>(Dictionary<string, string> dict) where T : new()
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                item.SetValue(obj, GetValue(item.GetValue(obj), dict, item));
            }

            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                item.SetValue(obj, GetValue(item.GetValue(obj), dict, item));
            }

            return (T)obj;
        }

        private dynamic GetValue(object val, Dictionary<string, string> dict, MemberInfo item) => val switch
        {
            int => Convert.ToInt32(dict[item.Name]),
            double => Convert.ToDouble(dict[item.Name]),
            _ => dict[item.Name]
        };
    }
}