using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class Program
    {
        static void Main(string[] args)
        {
            maxheap<int> heap = new maxheap<int>();
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(10);
            heap.Insert(13);
            heap.Insert(9);
            heap.Insert(9);
            heap.Insert(7);
            heap.Insert(17);

            Console.WriteLine(heap.Print());

        }
    }
}
