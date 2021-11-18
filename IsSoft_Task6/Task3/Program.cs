using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Task3
{
    class Program
    {
        static readonly List<(string Name, Vacation Vacation)> _objects = new();
        static readonly string datafile = "data.csv";

        static void Main(string[] args)
        {
            ReadDataFile(datafile);
            GetVacations();
        }

        static void GetVacations()
        {
            var vacations = _objects.Where(nv => nv.Vacation.IsInSecondHalfOf2016())
                .GroupBy(nv => nv.Name)
                .Select(g => new Person(g.Key, g.Select(v => v.Vacation).ToArray()));

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");

            File.WriteAllText("vacations.json", JsonConvert.SerializeObject(vacations));
            Console.WriteLine("List of vacations has been saved in vacations.json");
        }

        static void ReadDataFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"{Path.GetFullPath(filename)} not found");
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            using var sr = new StreamReader(filename);
            string line;
            var i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                i++;
                try
                {
                    var data = line.Split(",");
                    _objects.Add((data[0], new(DateTime.Parse(data[1]), DateTime.Parse(data[2]))));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Line {i}: {ex.Message}");
                }
            }

            Console.WriteLine("File successfully read");
        }
    }
}
