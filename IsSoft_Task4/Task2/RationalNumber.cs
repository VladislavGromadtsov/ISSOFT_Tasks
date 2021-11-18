using System;

namespace Task2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        private int numerator;
        private int denominator;

        public int Numerator => numerator;
        public int Denominator => denominator;

        public RationalNumber(int n = 1, int d = 1)
        {
            if (d == 0)
                throw new DivideByZeroException("Denominator can not be zero!");
            var gcd = GCD(n, d);
            if (gcd == 0)
            {
                (numerator, denominator) = (n, d);
            }
            else
            {
                (numerator, denominator) = (n/gcd, d/gcd);
            }
        }

        private int GCD(int n, int d)
        {
            n = Math.Abs(n);
            d = Math.Abs(d);
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    var temp = n;
                    n = d;
                    d = temp % d;
                }
                else break;
            }
            if (d != 0 && n != 0) return d;
            return 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is RationalNumber rational && Numerator == rational.Numerator && Denominator == rational.Denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }

        public override int GetHashCode() => (Numerator, Denominator).GetHashCode();

        public int CompareTo(RationalNumber other) => ((double)this).CompareTo((double)other);

        public static RationalNumber Add(RationalNumber a, RationalNumber b)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));

            return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber Sub(RationalNumber a, RationalNumber b)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));

            return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber Mul(RationalNumber a, RationalNumber b)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));

            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber Div(RationalNumber a, RationalNumber b)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));
            if (b.Numerator == 0)
                throw new DivideByZeroException("Can not be divided by zero");

            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b) => Add(a, b);

        public static RationalNumber operator -(RationalNumber a, RationalNumber b) => Sub(a, b);

        public static RationalNumber operator *(RationalNumber a, RationalNumber b) => Mul(a, b);

        public static RationalNumber operator /(RationalNumber a, RationalNumber b) => Div(a, b);

        public static explicit operator double(RationalNumber number)
        {
            
            return (double)number.Numerator / number.Denominator;
        }

        public static implicit operator RationalNumber(int number) => new(number);
    }
}