using System;
using System.Collections.Generic;
using System.Text;

namespace StacksBackedByArray
{
    class Stack<T>
    {
        T[] array = new T[1];
        int count = 0;
        public Stack()
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

        public void Push(T add)
        {
            if (count == array.Length)
            {
                Resize(array.Length * 2);
            }
            array[count] = add;
            count++;
        }

        public void Pop()
        {
            if (count <= array.Length/2)
            {
                Resize(array.Length / 2);
            }
            array[count] = default(T);
            count--;
        }

        public T Peek()
        {
            return array[count-1];
        }
    }
}
