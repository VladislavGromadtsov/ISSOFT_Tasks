using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Name"] = "Vlad",
                ["email"] = "vg@gmail.com",
                ["age"] = "10",
                ["Description"] = "Description"
            };

            var testEntity = SimpleBinder.Instance.Bind<Task2Testing>(dict);
            Console.WriteLine(testEntity.Name);
            Console.WriteLine(testEntity.Email);
            Console.WriteLine(testEntity.Age);
            Console.WriteLine(testEntity.Description);
        }
    }
}
