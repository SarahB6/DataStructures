using System;

namespace QueueBackedByArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("hello");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("ello");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("llo");
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());

        }
    }
}
