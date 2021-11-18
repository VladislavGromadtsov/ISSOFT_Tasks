using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Program
    {
        static readonly List<(string, double, double)> _objects = new();
        static readonly string datafile = "data.txt";

        static void Main(string[] args)
        {
            ReadDataFile(datafile);
            Console.WriteLine(KnnAlgorithm.Knn(_objects, 5, 7, 10));
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
            while ((line = sr.ReadLine()) != null)
            {
                var data = line.Split(",");
                _objects.Add((data[0], Convert.ToDouble(data[1]), Convert.ToDouble(data[2])));
            }

            Console.WriteLine("File successfully read");
        }
    }
}
