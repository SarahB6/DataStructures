using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class Node<T>
    {
        public Node<T> right;
        public Node<T> left;
        public Node<T> down;
        public T value;
        public int height = 1;

        public Node(T input)
        {
            this.value = input;
        }

    }
}
