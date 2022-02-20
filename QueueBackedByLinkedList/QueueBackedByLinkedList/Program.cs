using System;

namespace QueueBackedByLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("hello");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("lo");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("o");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
