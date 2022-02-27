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
            queue.Dequeue(); // gets rid of hello
            Console.WriteLine(queue.Peek());
            queue.Dequeue(); // gets rid of ello
            Console.WriteLine(queue.Peek());
            queue.Enqueue("word");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("wor");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("wo");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("w");
            Console.WriteLine(queue.Peek());
            queue.Enqueue("other");
            Console.WriteLine(queue.Peek());


        }
    }
}
