using System;

namespace BinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.insert(4);
            tree.insert(2);
            tree.insert(6);
            tree.insert(8);
            tree.insert(5);
            tree.delete(4);


        }
    }
}
