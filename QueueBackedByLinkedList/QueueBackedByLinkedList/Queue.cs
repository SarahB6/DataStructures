using System;
using System.Collections.Generic;
using System.Text;

namespace QueueBackedByLinkedList
{
    class Queue<T>
    {
        DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public Queue()
        {

        }

        public void Enqueue(T add)
        {
            list.AddLast(add);
        }

        public T Dequeue()
        {
            T first = list.head.input;
            list.RemoveFirst();
            return first;
        }

        public T Peek()
        {
            return list.head.input;

        }
    }
}
