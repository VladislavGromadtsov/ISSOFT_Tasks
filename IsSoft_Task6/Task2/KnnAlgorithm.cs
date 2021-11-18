using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public static class KnnAlgorithm
    {
        public static string Knn(List<(string Name, double X, double Y)> objects, double x, double y, int k)
        {
            if (objects == null || objects.Count == 0)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            if (k <= 0)
            {
                throw new ArgumentException("k cannot be less or equals zero.");
            }

            if (k > objects.Count)
            {
                throw new ArgumentException("k must be greater or equals objects number.");
            }

            var result = objects.AsParallel()
                .Select(obj => new { obj.Name, Distance = Distance(obj.X, obj.Y, x, y) })
                .OrderBy(x => x.Distance).Take(k)
                .GroupBy(x => x.Name)
                .Select(x => (x.Key, x.Count()))
                .OrderBy(x => x.Item2)
                .First().Key;

            return result;

            static double Distance(double x1, double y1, double x2, double y2) => Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}