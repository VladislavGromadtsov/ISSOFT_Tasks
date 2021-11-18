using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Task1Library
{
    public class Logger
    {
        private readonly string _path;

        public Logger(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "Check filename");
            }

            _path = Path.GetFullPath(fileName);
        }

        public void Track(object obj)
        {
            var type = obj.GetType();

            if (type.IsDefined(typeof(TrackingEntity), true))
            {
                var objects = new Dictionary<string, string>();

                foreach (var field in type.GetFields())
                {
                    var attribute = field.GetCustomAttribute<TrackingProperty>();
                    if (attribute != null)
                    {
                        objects[GetName(field, attribute)] = field.GetValue(obj)?.ToString();
                    }
                }

                foreach (var property in type.GetProperties())
                {
                    var attribute = property.GetCustomAttribute<TrackingProperty>();
                    if (attribute != null)
                    {
                        objects[GetName(property, attribute)] = property.GetValue(obj)?.ToString();
                    }
                }

                File.WriteAllText(_path, JsonSerializer.Serialize(objects));
            }

            static string GetName(MemberInfo member, TrackingProperty attribute) => string.IsNullOrEmpty(attribute.PropertyName) ? member.Name : attribute.PropertyName;
        }
    }
}