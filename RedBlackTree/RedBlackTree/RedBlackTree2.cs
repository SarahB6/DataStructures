using System;
using System.Collections.Generic;
using System.Text;

class RedBlackTree2<TValue> where TValue : IComparable<TValue>
{
    private Node root;

    private class Node
    {
        public TValue Value;
        public Node Left;
        public Node Right;
        public bool IsRed;

        public Node(TValue value)
        {
            Value = value;
            IsRed = true;
        }
    }

    public void Insert(TValue value)
    {
        root = Insert(root, value);
        root.IsRed = false;
    }

    private Node Insert(Node node, TValue value)
    {
        if (node == null)
            return new Node(value);

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

    private bool IsRed(Node node)
    {
        if (node == null)
            return false;
        return node.IsRed;
    }

    private Node RotateLeft(Node node)
    {
        Node x = node.Right;
        node.Right = x.Left;
        x.Left = node;
        x.IsRed = node.IsRed;
        node.IsRed = true;
        return x;
    }

    private Node RotateRight(Node node)
    {
        Node x = node.Left;
        node.Left = x.Right;
        x.Right = node;
        x.IsRed = node.IsRed;
        node.IsRed = true;
        return x;
    }

    private void FlipColors(Node node)
    {
        node.IsRed = true;
        node.Left.IsRed = false;
        node.Right.IsRed = false;
    }
}
