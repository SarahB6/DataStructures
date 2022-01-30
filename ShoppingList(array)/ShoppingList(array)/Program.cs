using System;
using System.Collections.Generic;

namespace ShoppingList_array_
{
    class Program
    {
        public static void Add(LinkedList<string> input, string item)
        {
            input.AddLast(item);
        }
        public static void Remove(LinkedList<string> input, string item)
        {
            input.Remove(item);
        }

        public static string View(LinkedList<string> input)
        {
            string toReturn = "";
            LinkedListNode<string> currentNode = input.First;

            for (int i = 0; i<input.Count; i++)
            {
                toReturn += $"{currentNode.Value}\n";
                currentNode = currentNode.Next;
               
            }
            return toReturn;
        }

        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            Add(list, "apple");
            Add(list, "popcorn");
            Add(list, "chocolate");
            Add(list, "flour");
            Console.WriteLine(View(list));
            Remove(list, "popcorn");
            Console.WriteLine();
            Console.WriteLine(View(list));
        }
    }
}
