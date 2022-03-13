using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    class Program
    {
        public static bool testQuickSort(int iterations, int arraySize, int min, int max)
        {
            for (int a = 0; a < iterations; a++)
            {
                Random rand = new Random();
                List<int> check = new List<int>();
                for (int i = 0; i < arraySize; i++)
                {
                    check.Add(rand.Next(min, max));

                }
                QuickSorter<int> sort = new QuickSorter<int>();
                sort.QuickSort(check, 0, check.Count-1);
                int previous = check[0];
                for (int i = 1; i < check.Count; i++)
                {
                    if (check[i - 1] > check[i])
                    {
                        return false;
                    }
                }

            }
            return true;

        }
        static void Main(string[] args)
        {
            QuickSorter<int> sort = new QuickSorter<int>();
            List<int> first = new List<int>();
            first.Add(7);
            first.Add(4);
            first.Add(3);
            first.Add(6);
            first.Add(2);
            first.Add(1);
            first.Add(5);
            sort.QuickSort(first, 0, first.Count-1);
            bool response = testQuickSort(100, 9, 0, 100);
        }
    }
}
