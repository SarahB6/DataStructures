using System;

namespace DoublyLinkedList
{
    class Program
    {
        public static void nextTrack(DoubleLinkedList<string> list, string current)
        {
           if(!list.index(current).Equals(list.Count()))
            {
                Console.WriteLine(list.outputAtIndex(list.index(current)+1));
            }
        }

        public static void previousTrack(DoubleLinkedList<string> list, string current)
        {
            if (!list.index(current).Equals(list.head))
            {
                Console.WriteLine(list.outputAtIndex(list.index(current)-1));
            }
        }

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
            nextTrack(list, "2");
            previousTrack(list, "2");

        }
    }
}
