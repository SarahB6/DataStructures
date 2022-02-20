using System;
using System.Collections.Generic;
using System.Text;

namespace StackBackedByLinkedList
{
    class Node<T>
    {
        public Node<T> next;
        public Node<T> previous;
        public T input;

        public Node(T input)
        {
            this.input = input;
            next = null;
            previous = null;
        }
    }
}