using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix matrix = new(5, 6);
            matrix[0, 1] = 1;
            matrix[1, 1] = 1;
            matrix[1, 2] = 1;
            matrix[2, 1] = 1;
            matrix[4, 4] = 1;
            matrix[2, 3] = 1;
            matrix[1, 4] = 1;

            Console.WriteLine(matrix);

            Console.WriteLine($"Count of 1: {matrix.GetCount(1)}");
            matrix[0, 1] = 0;
            Console.WriteLine(matrix);
            Console.WriteLine($"Count of 1: {matrix.GetCount(1)}");

            Console.WriteLine("NonzeroElements:\n");
            foreach (var el in matrix.GetNonzeroElements())
            {
                Console.WriteLine($"i = {el.i}  j = {el.j}");
            }
        }
    }
}
