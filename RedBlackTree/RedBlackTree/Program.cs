using System;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<int> rb = new RedBlackTree<int>();
            rb.Insert(3);
            rb.Insert(1);
            rb.Insert(7);
            rb.Insert(10);
            rb.Insert(14);
            rb.Insert(4);
            rb.Insert(81);
            rb.Insert(18);
            Console.WriteLine(rb.Validate());
        }
    }
}
