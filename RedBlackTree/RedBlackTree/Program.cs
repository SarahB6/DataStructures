using System;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree2<int> rb = new RedBlackTree2<int>();
            rb.Insert(3);
            rb.Insert(1);
            rb.Insert(7);
            rb.Insert(10);

        }
    }
}
