using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Task3
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("vacations")]
        public List<Vacation> Vacations { get; set; } = new();

        public Person(string name, params Vacation[] vacations)
        {
            if (vacations == null)
            {
                throw new ArgumentNullException(nameof(vacations));
            }

            Name = name;
            foreach (var item in vacations)
            {
                Vacations.Add(item);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"{Name}: ");
            foreach (var item in Vacations)
            {
                sb.Append(item + " ");
            }

            return sb.ToString();
        }
    }
}