using System;
using System.Runtime.InteropServices.ComTypes;

namespace Task1
{
    public static class DiagonalMatrixExtension
    {
        public static DiagonalMatrix<T> Sum<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b, Func<T, T, T> func)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));
            _ = func ?? throw new ArgumentNullException(nameof(func));

            if (a.Size < b.Size)
            {
                (a, b) = (b, a);
            }

            DiagonalMatrix<T> result = new(a.Size);
            for (var i = 0; i < b.Size; i++)
            {
                result[i, i] = func(a[i, i], b[i, i]);
            }

            for (var i = b.Size; i < a.Size; i++)
            {
                result[i, i] = a[i, i];
            }

            return result;
        }
    }
}