using System;

var stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);
stack.Push(6);

Console.WriteLine(stack);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack);
Console.WriteLine("Stack is empty: " + stack.IsEmpty());

var reversedStack = stack.Reverse();
Console.WriteLine("\n" + reversedStack);
Console.WriteLine(stack);
reversedStack.Push(10);

Console.WriteLine("\n" + reversedStack);
