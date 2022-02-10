using System;

namespace makeLinkedListShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.AddFirst("1");
            list.AddLast("2");
            list.AddFirst("0");
            //list.RemoveFirst();
            list.RemoveLast();
            Console.WriteLine("a");
            //Console.WriteLine(list);
            list.Clear();
            //Console.WriteLine(list.Contains("1"));
            //Console.WriteLine(list.Contains("7"));

            


        }
    }
}
