using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new DiagMatrix(1, 2, 3, 4, 5);
            var b = new DiagMatrix(1, 2, 3, 4, 5);
            Console.WriteLine("Sum A and B:\n" + DiagonalMatrixHelper.Sum(a, b).ToString());

            var c = new DiagMatrix(9, 8, 7, 6, 5, 4);
            Console.WriteLine("\nA is equals B: " + a.Equals(b));
            Console.WriteLine("\nB is equals A: " + b.Equals(a));
            Console.WriteLine("\nC is equals B: " + c.Equals(b));

            Console.WriteLine("\nSum A and C:\n" + DiagonalMatrixHelper.Sum(a, c).ToString());

            Console.WriteLine("Sum of the diagonal elements of A: " + a.Track());
        }
    }
}
