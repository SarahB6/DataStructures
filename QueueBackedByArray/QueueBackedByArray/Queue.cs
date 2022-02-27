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
        int tail = 0; //IMPLEMENT
        
        public Queue()
        {
        }

        public void Resize(int newSize)
        {
            T[] newA = new T[newSize];
            int counter = 0;
            for (int i = head; i < array.Length; i++)
            {
                newA[counter] = array[i];
                counter++;
            }
            for (int i = 0; i < head; i++)
            {
                newA[counter] = array[i];
                counter++;
            }
            array = newA;
        }
        public void Enqueue(T input)
        {
            if(index==array.Length && head!=0)
            {
                index = 0;
                array[0] = input;
            }
            else if(index == head && head != 0)
            {
                index = array.Length;
                Resize(array.Length * 2);
                array[index] = input;
            }
            else if(index == array.Length)
            {
                Resize(array.Length * 2);
                array[index] = input;
            }
            else
            {
                array[index] = input;
            }
            index++;
            
            
        }

        public void Dequeue()
        {
            if (index == array.Length && head != 0)
            {
                head = 0;
            }
            else
            {
                head++;
            }
        }

        public T Peek()
        {
            return array[head];
        }
    }
}
