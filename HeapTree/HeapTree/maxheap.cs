using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class maxheap<T>
    where T : IComparable<T>
    {
        List<T> list = new List<T>();
        int remove = 0;
        public void Insert(T toAdd)
        {
            list.Add(toAdd);
            HeapifyUp(toAdd);
        }

        public int getLeftChild(int i)
        {
            return i * 2 + 1;
        }

        public int getRightChild(int i)
        {
            return i * 2 + 2;
        }
        public int getParent(int i)
        {
            if (i % 2 == 1)
            {
                return i / 2;
            }
            return (i - 1) / 2;
        }
        public void HeapifyUp(T toAdd)
        {
            int add = list.Count - 1;
            while (list[add].CompareTo(list[getParent(add)]) > 0)
            {
                T val = list[add];
                list[add] = list[getParent(add)];
                list[getParent(add)] = val;
                add = getParent(add);
            }
        }

        public T Pop()
        {
            T root = list[0];
            list[0] = list[list.Count - 1];
            list.Remove(list[list.Count - 1]);
            remove = 0;
            while (getLeftChild(remove) < list.Count)
            {
                HeapifyDown();
                remove++;
            }
            return root;
        }

        public void HeapifyDown()
        {
            if (list[remove].CompareTo(list[getLeftChild(remove)]) <= 0)
            {
                T val = list[remove];
                list[remove] = list[getLeftChild(remove)];
                list[getLeftChild(remove)] = val;
                remove = getLeftChild(remove);
            }
            else if (getRightChild(remove) < list.Count)
            {
                if (list[remove].CompareTo(list[getRightChild(remove)]) <= 0)
                {
                    T val = list[remove];
                    list[remove] = list[getRightChild(remove)];
                    list[getRightChild(remove)] = val;
                    remove = getRightChild(remove);
                }
            }
        }

        public string Print()
        {
            string s = "";
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                s += $" {Pop()}";
                //s += $" {list[i]}";
            }
            return s;
        }
    }
}