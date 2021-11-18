using System.Runtime.InteropServices.ComTypes;

namespace Task01
{
    public class DiagMatrix
    {
        private int[] _elements;
        private int _size;

        public DiagMatrix(params int[] array)
        {
            if (array == null || array.Length == 0)
            {
                _size = 0;
                _elements = new int[] { };
            }
            else
            {
                _elements = new int[array.Length];
                _size = array.Length;

                for (var i = 0; i < array.Length; i++)
                {
                    _elements[i] = array[i];
                }
            }
        }

        public int Size => _size;

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= _size || j < 0 || j >= _size)
                {
                    return 0;
                }

                return i != j ? 0 : _elements[i];
            }
            set
            {
                if (i >= 0 && i < _size && j >= 0 && j < _size)
                {
                    if (i == j)
                    {
                        _elements[i] = value;
                    }
                }
            }
        }

        public int Track()
        {
            var sum = 0;
            for (var i = 0; i < _size; i++)
            {
                sum += _elements[i];
            }

            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            DiagMatrix matrix = obj as DiagMatrix;
            if (matrix as DiagMatrix == null)
            {
                return false;
            }

            if (_size != matrix.Size)
            {
                return false;
            }

            for (var i = 0; i < _size; i++)
            {
                if (_elements[i] != matrix[i,i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var str = "";
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    str += $"{this[i, j]}\t";
                }

                str += "\n";
            }

            return str;
        }
    }
}