using System;

class MyStack<T>
{
    private T[] items = new T[100];
    private int top = -1;

    public void Push(T item)
    {
        if (top == items.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        items[++top] = item;
    }

    public T Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow");
            return default(T)!;
        }
        return items[top--];
    }

    public T Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty");
            return default(T)!;
        }
        return items[top];
    }
}

class Program
{
    static void Main()
    {
        MyStack<int> intStack = new MyStack<int>();
        intStack.Push(10);
        intStack.Push(20);
        intStack.Push(30);
        Console.WriteLine("Peek: " + intStack.Peek());
        Console.WriteLine("Pop: " + intStack.Pop());

        MyStack<string> strStack = new MyStack<string>();
        strStack.Push("Nepal");
        strStack.Push("Kathmandu");
        Console.WriteLine("Peek: " + strStack.Peek());
        Console.WriteLine("Pop: " + strStack.Pop());
    }
}
