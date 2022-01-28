using System;
using System.Collections.Generic;

namespace SectionSorter
{
    class Program
    {
        public static int getSmallestIndex(List<int> input, int index)
        {
            int smallest = input[index];
            int smallestIndex = index;
            for(int i = index; i<input.Count; i++)
            {
                if (input[i] < smallest)
                {
                    smallest = input[i];
                    smallestIndex = i;
                }
            }
            return smallestIndex;
        }
        public static void sectionSort(List<int> input)
        {
            int c = 0;
            while(c<input.Count-1)
            {
                int smallestInd = getSmallestIndex(input, c);
                int smallestVal = input[smallestInd];
                input[smallestInd] = input[c];
                input[c] = smallestVal;
                c++;
            }
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(2);
            list.Add(6);
            list.Add(4);
            list.Add(1);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            sectionSort(list);
            Console.WriteLine("\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
