using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    class Sorter<T>
        where T : IComparable<T>
    {
        
        public Sorter()
        {
        }
        public List<T> Sort(List<T> list)
        {
            int midpt = list.Count / 2;

            List<T> left = new List<T>();
            List<T> right = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i < midpt)
                {
                    left.Add(list[i]);
                }
                else
                {
                    right.Add(list[i]);
                }
            }

            if (list.Count < 2)
            {
                return list;
            }
            return Merge(Sort(left), Sort(right));
        }

        public List<T> Merge(List<T> first, List<T> second)
        {
            List<T> sorted = new List<T>();
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < second.Count + first.Count; i++)
            {
                if (count1 >= first.Count)
                {
                    sorted.Add(second[count2]);
                    count2++;
                }
                else if (count2 >= second.Count)
                {
                    sorted.Add(first[count1]);
                    count1++;
                }
                else if (first[count1].CompareTo(second[count2]) >= 0)
                {
                    sorted.Add(second[count2]);
                    count2++;
                }
                else
                {
                    sorted.Add(first[count1]);
                    count1++;
                }
            }
            return sorted;

        }

    }
}
