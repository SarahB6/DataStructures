using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            Console.WriteLine(list.IsEmpty());
            list.AddFirst("2");
            list.AddFirst("1");
            list.AddLast("3");
            list.AddLast("4");
            list.AddFirst("0");
            Console.WriteLine(list);
            list.AddAfter("7", list.head.next);
            list.AddBefore("y", list.head.next.next.next);
            Console.WriteLine(list);
            Console.WriteLine(list.Count());
            Console.WriteLine(list.IsEmpty());
        }
    }
}
