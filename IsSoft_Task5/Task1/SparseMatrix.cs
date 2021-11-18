using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Task1
{
    public class SparseMatrix : IEnumerable<int>
    {
        private readonly Dictionary<(int i, int j), int> _data;
        private readonly int _rows;
        private readonly int _columns;

        public SparseMatrix(int n, int m)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number of rows should be > 0");
            }

            if (m <= 0)
            {
                throw new ArgumentException("Number of columns should be > 0");
            }

            _data = new();
            (_rows, _columns) = (n, m);
        }

        public int Rows => _rows;
        public int Columns => _columns;
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rows)
                {
                    throw new ArgumentException("I should be > 0 and < count of rows");
                }
                if (j < 0 || j >= Columns)
                {
                    throw new ArgumentException("I should be > 0 and < count of columns");
                }

                return _data.ContainsKey((i, j)) ? _data[(i, j)] : default;
            }
            set
            {
                if (i < 0 || i >= Rows)
                {
                    throw new ArgumentException("I should be > 0 and < count of rows");
                }
                if (j < 0 || j >= Columns)
                {
                    throw new ArgumentException("I should be > 0 and < count of columns");
                }

                if (value == default)
                {
                    _data.Remove((i, j));
                }
                else
                {
                    _data[(i, j)] = value;
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            int counter = 0;
            foreach (var el in this)
            {
                str += el + "\t";

                if (++counter % _columns == 0)
                {
                    str += "\n";
                }
            }

            return str;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return _data.ContainsKey((i, j)) ? _data[(i, j)] : default;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<(int i, int j, int value)> GetNonzeroElements()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_data.ContainsKey((j, i)))
                    {
                        yield return (j, i, _data[(j, i)]);
                    }
                }
            }
        }

        public int GetCount(int x)
        {
            if (x != 0)
            {
                return _data.Count(elm => elm.Value == x);
            }
            else
            {
                return Rows * Columns - _data.Count;
            }
        }
    }
}