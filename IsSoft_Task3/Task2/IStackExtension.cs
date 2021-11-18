using System;

public static class IStackExtension
{
    public static IStack<T> Reverse<T>(this IStack<T> stack) where T : struct
    {
        if (stack == null)
        {
            throw new ArgumentNullException(nameof(stack), "Stack is null!");
        }

        var newStack = new Stack<T>();
        var elements = new T[50];
        var counter = 0;

        while (!stack.IsEmpty())
        {
            var buf = stack.Pop();
            newStack.Push(buf);
            elements[counter++] = buf;
        }
        
        for (var i = counter - 1; i >= 0; i--)
        {
            stack.Push(elements[i]);
        }

        return newStack;
    }
}