using System;
using System.Collections.Generic;

namespace AVLSearchTree
{
    class Program
    {
        static void Fill(Node<char> node, char[,] grid, int r, int c)
        {
            if(node == null)
            {
                return;
            }
            
            grid[r, c] = node.value;
            int offset = ((int)Math.Pow(2, grid.GetLength(0) - 1 - r - 1));
            Fill(node.leftChild, grid, r + 1, c - offset);
            Fill(node.rightChild, grid, r + 1, c + offset);
        }

        static char[,] CreateGrid(Node<char> root)
        {
            char[,] grid = new char[root.Height, 2*((int)Math.Pow(2, root.Height))];
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x] = ' ';
                }
            }
            return grid;
        }

        static List<char> preOrder(Node<char> root)
        {
            List<char> queue = new List<char>();
            preOrderR(root, queue);
            return queue;
        }

        static void preOrderR(Node<char> current, List<char> queue)
        {
            if(current == null)
            {
                return;
            }
            queue.Add(current.value);
            preOrderR(current.leftChild, queue);
            preOrderR(current.rightChild, queue);
        }

        static List<char> inOrder(Node<char> root)
        {
            List<char> queue = new List<char>();
            inOrderR(root, queue);
            return queue;
        }

        static void inOrderR(Node<char> current, List<char> queue)
        {
            if (current == null)
            {
                return;
            }

            inOrderR(current.leftChild, queue);
            queue.Add(current.value);
            inOrderR(current.rightChild, queue);
        }

        static List<char> postOrder(Node<char> root)
        {
            List<char> queue = new List<char>();
            postOrderR(root, queue);
            return queue;
        }

        static void postOrderR(Node<char> current, List<char> queue)
        {
            if (current == null)
            {
                return;
            }

            postOrderR(current.leftChild, queue);
            postOrderR(current.rightChild, queue);
            queue.Add(current.value);
        }

        static List<char> BredthFirstTraverse(Node<char> root)
        {
            Queue<Node<char>> queue = new Queue<Node<char>>();
            List<char> val = new List<char>();
            queue.Enqueue(root);
            
            while (queue.Count > 0)
            {
                Node<char> current = queue.Dequeue();
                if (current == null) continue;

                val.Add(current.value);
                queue.Enqueue(current.leftChild);
                queue.Enqueue(current.rightChild);

            }
            return val;

       
        }
        static void PrintGrid(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    Console.Write(grid[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void Print(Node<char> root)
        {
            char[,] grid = CreateGrid(root);
            Fill(root, grid, 0, (grid.GetLength(1) - 1) / 2);
            PrintGrid(grid);
            Console.WriteLine("------------------------------------------------------");
        }
        static void Main(string[] args)
        {
            
                

            AVLSearchTree<char> tree = new AVLSearchTree<char>();
            tree.Insert('d');
            tree.Insert('a');
            tree.Insert('b');
            tree.Insert('n');
            tree.Insert('c');
            List<char> l = inOrder(tree.GetRoot());
        }
    }
}
