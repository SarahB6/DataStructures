using System;
using System.Collections.Generic;
using System.Text;

namespace makeLinkedListShoppingList
{
    class Node<T>
    {
        public Node<T> next;
        public T input;

        public Node(T input)
        {
            this.input = input;
        }
    }
}
