using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    
    class Program
    {
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
        }
    }
}
