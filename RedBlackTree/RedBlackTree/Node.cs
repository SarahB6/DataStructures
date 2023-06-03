using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class Node<T>
    where T:IComparable<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public bool IsRed;

        public Node(T value)
        {
            Value = value;
            IsRed = true;
        }
    }
}
