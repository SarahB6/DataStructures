using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HeapTree
{
    class Program
    {
        class CustomIntComparer : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                return y.CompareTo(x);
            }
        }

        static void Main(string[] args)
        {
            CustomIntComparer comparer = new CustomIntComparer();
            heap<int> heap = new heap<int>(comparer);
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
