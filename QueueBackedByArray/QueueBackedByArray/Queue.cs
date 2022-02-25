using System;
using System.Collections.Generic;
using System.Text;

namespace QueueBackedByArray
{
    class Queue<T>
    {
        T[] array = new T[1];
        int index = 0;
        int head = 0;
        
        public Queue()
        {

        }

        public void Resize(int newSize)
        {
            T[] newA = new T[newSize];
            for (int i = 0; i < array.Length; i++)
            {
                newA[i] = array[i];
            }
            array = newA;
        }

        public void Enqueue(T input)
        {
            if(index==array.Length)
            {
                Resize(array.Length * 2);
            }
            array[index] = input;
            index++;
        }

        public void Dequeue()
        {
            head++;
        }

        public T Peek()
        {
            return array[head];
        }
    }
}
