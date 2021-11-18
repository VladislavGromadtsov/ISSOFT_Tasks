using System;

namespace ISsoft_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment necessary task and run the project

            //Task1();
            //Task2();
            //Task3();
        }

        static void Task3()
        {
            Console.Write("Input number of digits: ");
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            Console.WriteLine("Input array:");

            for (var i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\nArray: [");
            for (var i = 0; i < n; i++)
            {
                if (i != n - 1)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i] + "]\n");
                }
            }

            var minValue = array[0];
            var maxValue = array[0];
            var minPos = 0;
            var maxPos = 0;
            for (var i = 0; i < n; i++)
            {
                if (array[i] >= maxValue)
                {
                    maxValue = array[i];
                    maxPos = i;
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                    minPos = i;
                }
            }

            var startPos = minPos;
            var endPos = maxPos;
            if (maxPos < minPos)
            {
                startPos = maxPos;
                endPos = minPos;
            }

            var sum = 0;
            Console.Write("\nResult array: [");
            for (var i = startPos; i <= endPos; i++)
            {
                sum += array[i];

                if (i != endPos)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i] + "]\n");
                }
            }

            Console.Write($"Sum: {sum}");
        }

        static void Task2()
        {
            Console.Write("Input your first 9 digits of ISBN: ");
            var isbn = Console.ReadLine();
            var coefficient = 10;
            var sumOfWeights = 0;

            for (var i = 0; i < 9; i++)
            {
                var temp = isbn[i] - '0';
                sumOfWeights += temp * coefficient;
                coefficient--;
            }

            var controlNumber = 11 - sumOfWeights % 11;
            isbn += (controlNumber == 10) ? "X" : controlNumber.ToString();

            Console.WriteLine("\nResult:\n" + isbn);
        }

        static void Task1()
        {
            Console.Write("Input:\na = ");
            var a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = int.Parse(Console.ReadLine());
            var counter = 0;

            var array = new int[b - a + 1];

            for (var i = a; i <= b; i++)
            {
                var temp = i;
                var countOfTwo = 0;

                while (temp > 0)
                {
                    var remainder = temp % 3;

                    if (remainder == 2)
                    {
                        countOfTwo++;
                    }

                    temp /= 3;
                }

                if (countOfTwo == 2)
                {
                    array[counter] = i;
                    counter++;
                }
            }

            Console.WriteLine("\nResult: ");
            for (var i = 0; i < counter; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
