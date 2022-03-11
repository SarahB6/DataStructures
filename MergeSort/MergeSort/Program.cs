using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    
    class Program
    {
        public static bool testMergeSort(int iterations, int arraySize, int min, int max)
        {
            for (int a = 0; a < iterations; a++)
            {
                Random rand = new Random();
                List<int> check = new List<int>();
                for (int i = 0; i < arraySize; i++)
                {
                    check.Add(rand.Next(min, max));

                }
                Sorter<int> sort = new Sorter<int>();
                List<int> sorted = sort.Sort(check);
                int previous = sorted[0];
                for(int i = 1; i<sorted.Count; i++)
                {
                    if (sorted[i-1] > sorted[i])
                    {
                        return false;
                    }
                }

            }
            return true;
            
        }
        static void Main(string[] args)
        {
            Sorter<int> sort = new Sorter<int>();
            List<int> first = new List<int>();
            first.Add(38);
            first.Add(27);
            first.Add(43);
            first.Add(3);
            first.Add(9);
            first.Add(82);
            first.Add(10);

           List<int> result = sort.Sort(first);
            bool response = testMergeSort(100, 200, 0, 100);
        }
    }
}
