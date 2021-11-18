using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber num1 = new(10, 7);
            RationalNumber num2 = new(-8, 6);
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1 - num2);
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1 / num2);

            Console.WriteLine(new RationalNumber(15, 6).GetHashCode());

            Console.WriteLine(new RationalNumber(5, 2).CompareTo(new RationalNumber(15, 6)));

            var num3 = (double)new RationalNumber(10, 4);
            Console.WriteLine(num3);

            RationalNumber num4 = 10;
            Console.WriteLine(num4);
        }
    }
}
