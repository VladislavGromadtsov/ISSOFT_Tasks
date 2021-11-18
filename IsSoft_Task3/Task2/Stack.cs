using System;

public class Stack<T> : IStack<T> where T : struct
{
    private readonly T[] _elements;
    private readonly int _size = 50;

    public int Count { get; private set; } = 0;

    public Stack() => _elements = new T[_size];

    public void Push(T e)
    {
        if (Count == _size)
        {
            throw new InvalidOperationException("Stack is full!");
        }

        _elements[Count++] = e;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty!");
        }

        return _elements[--Count];
    }

    public bool IsEmpty() => Count == 0;

    public override string ToString()
    {
        var str = "";

        for (var i = 0; i < Count; i++)
        {
            str += _elements[i] + " ";
        }

        return str;
    }
}