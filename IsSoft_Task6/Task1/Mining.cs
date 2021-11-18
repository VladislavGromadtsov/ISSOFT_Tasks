using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public static class Mining
    {
        public static List<BigInteger> Factorization(BigInteger num)
        {
            if (num.Sign == -1)
            {
                num = BigInteger.Abs(num);
            }

            if (num < 2)
            {
                throw new ArgumentException(nameof(num));
            }

            var primeFactors = new List<BigInteger>();
            var div = 2;

            while (div * div <= num)
            {
                if (num % div == 0)
                {
                    primeFactors.Add(div);
                    num /= div;
                }
                else
                {
                    div++;
                }
            }

            if (num >= 1)
            {
                primeFactors.Add(num);
            }

            return primeFactors;
        }

        public static Task<List<BigInteger>> FactorizationAsync(BigInteger num)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            new Thread(Calculation).Start();
            return tcs.Task;

            void Calculation()
            {
                try
                {
                    var result = Factorization(num);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }

        public static async Task<BigInteger> Gcd(BigInteger num1, BigInteger num2)
        {
            var primeFactors1 = await FactorizationAsync(num1);
            var primeFactors2 = await FactorizationAsync(num2);

            IEnumerable<BigInteger> res;
            if (primeFactors1.Count <= primeFactors2.Count)
            {
                res = primeFactors1.Where(bi => primeFactors2.Contains(bi));
            }
            else
            {
                res = primeFactors2.Where(bi => primeFactors1.Contains(bi));
            }

            return !res.Any() ? 1 : res.Aggregate((x, y) => x * y);
        }
    }
}