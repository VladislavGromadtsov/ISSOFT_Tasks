using System;
using System.Diagnostics.CodeAnalysis;

namespace Task1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix<int> a = new DiagonalMatrix<int>(3);
            DiagonalMatrix<int> b = new DiagonalMatrix<int>(3);
            MatrixTracker<int> aMatrixTracker = new(a);
            for (var i = 0; i < 3; i++)
            {
                a[i, i] = i;
                b[i, i] = i + 3;
            }
            Console.WriteLine(a.ToString());
            a[0, 0] = 10;
            Console.WriteLine(a.ToString());
            aMatrixTracker.Undo();
            Console.WriteLine(a.ToString());
            aMatrixTracker.Undo();
            Console.WriteLine(a.ToString());

            static int func(int a, int b) => a + b;
            Console.WriteLine(a.Sum(b, func));
        }
    }
}
