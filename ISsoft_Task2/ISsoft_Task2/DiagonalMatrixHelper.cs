using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public static class DiagonalMatrixHelper
    {
        public static DiagMatrix Sum(DiagMatrix a, DiagMatrix b)
        {
            int[] result = new int[a.Size > b.Size ? a.Size : b.Size];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = a[i, i] + b[i, i];
            }

            return new DiagMatrix(result);
        }
    }
}
