using System;
using System.Collections.Generic;
using System.Text;

namespace StackBackedByLinkedList
{
    class Stack<T>
    {
        DoubleLinkedList<T> list = new DoubleLinkedList<T>();
        public Node<T> head = null;
        public Node<T> tail = null;
        public Stack()
        {

        }

        public void Push(T add)
        {
            list.AddLast(add);
        }

        public void Pop()

        {
            list.RemoveLast();
        }

        public T Peek()
        {
            return list.OutputAtIndex(list.Count()-1);
        }
    }
}
