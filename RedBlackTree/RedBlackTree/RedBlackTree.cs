using System;
using System.Collections.Generic;
using System.Text;
namespace RedBlackTree
{
    class RedBlackTree<T> where T : IComparable<T>
    {
        private Node<T> root;

    public void Insert(T value)
        {
            root = Insert(root, value);
            root.IsRed = false;
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
                return new Node<T>(value);

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = Insert(node.Left, value);
            else if (cmp > 0)
                node.Right = Insert(node.Right, value);
            else
                node.Value = value;

            if (IsRed(node.Right) && !IsRed(node.Left))
                node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left))
                node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right))
                FlipColors(node);

            return node;
        }

        private bool IsRed(Node<T> node)
        {
            if (node == null)
                return false;
            return node.IsRed;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> x = node.Right;
            node.Right = x.Left;
            x.Left = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            return x;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> x = node.Left;
            node.Left = x.Right;
            x.Right = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            return x;
        }

        private void FlipColors(Node<T> node)
        {
            node.IsRed = true;
            node.Left.IsRed = false;
            node.Right.IsRed = false;
        }

        public bool Validate()
        {
            Node<T> curr = root;
            int counter = 0;
            while (curr != null)
            {
                if (!curr.IsRed)
                {
                    counter++;
                }
                curr = curr.Left;
            }
            return ValidateR(root, 0, counter);

        }

        private bool ValidateR(Node<T> curr, int currentCount, int neededCount)
        {
            if (curr == null)
            {
                if (currentCount != neededCount)
                {
                    return false;
                }
                currentCount = 0;
            }
            else
            {
                if (!curr.IsRed)
                {
                    currentCount++;
                }
                ValidateR(curr.Left, currentCount, neededCount);
                ValidateR(curr.Right, currentCount, neededCount);
            }
            return true;
        }
    }
}
