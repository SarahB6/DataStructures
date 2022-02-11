using System;

namespace makeLinkedListShoppingList
{
    class Program
    {
        public static void AddItem(SinglyLinkedList<string> list, string item)
        {
            list.AddLast(item);
        }

        public static void RemoveItem(SinglyLinkedList<string> list, string item)
        {
            Node<string> toRemove = list.Search(item);
            list.removeSpecific(toRemove);

        }

        public static void View(SinglyLinkedList<string> list)
        {
            Console.WriteLine(list);
        }
        static void Main(string[] args)
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            AddItem(list, "eggs");
            AddItem(list, "chocolate");
            AddItem(list, "vanilla");
            AddItem(list, "raspberries");
            RemoveItem(list, "eggs");
            View(list);

            


        }
    }
}
