using System;
using System.Drawing;
using System.Security.Cryptography;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        private readonly T[] _elements;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size must be >= 0");

            _elements = new T[size];
        }

        public int Size => _elements.Length;

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new IndexOutOfRangeException("Indexes are out of range");
                
                return i != j ? default(T) : _elements[i];
            }
            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new IndexOutOfRangeException("Indexes are out of range");

                if (i == j)
                {
                    if (_elements[i].Equals(value)) return;
                    var oldElement = _elements[i];
                    _elements[i] = value;
                    OnElementChanged(new ElementChangedEventArgs<T>(i, oldElement, _elements[i]));
                }
            }
        }

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

        public override string ToString()
        {
            var str = "";
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    str += $"{this[i, j]}\t";
                }

                str += "\n";
            }

            return str;
        }
    }
}