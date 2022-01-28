using System;
using System.Collections.Generic;

namespace InsertionSorter
{
    class Program
    {
        public static void InsertionSort(List<int> input)
        {
            int count = 1;
            while(count <= input.Count)
            {
                for (int i = 0; i< count; i++)
                {
                    if (input[count-1] < input[i])
                    {
                        int og = input[i];
                        input[i] = input[count-1];
                        input[count-1] = og;
                    }
                }
                count++;
            }
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(8);
            list.Add(3);
            list.Add(4);
            list.Add(9);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            InsertionSort(list);
            Console.WriteLine("\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
