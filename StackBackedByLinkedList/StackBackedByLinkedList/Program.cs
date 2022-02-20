using System;

namespace StackBackedByLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("hello");
            Console.WriteLine(stack.Peek());
            stack.Push("lo");
            Console.WriteLine(stack.Peek());
            stack.Push("o");
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());
        }
    }
}
