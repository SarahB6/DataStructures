using System;
using System.Collections.Generic;
using System.Text;

namespace AVLSearchTree
{
    class Node<T>
    {
        public T value;
        public Node<T> leftChild;
        public Node<T> rightChild;
        public Node<T> parent;
        public int height;
        public int balance;

        public Node(T value)
        {
            this.value = value;
        }

    }
}

