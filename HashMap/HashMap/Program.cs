using System;
using System.Collections.Generic;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("e", 9); 
            h.Add(pair3);

            KeyValuePair<string, int> pair4 = new KeyValuePair<string, int>("f", 8);
            h.Add(pair4);

            Console.WriteLine(h.Contains(pair1));
            Console.WriteLine(h.Contains(pair2));
            KeyValuePair<string, int>[] array = new KeyValuePair<string, int>[5];
            h.CopyTo(array, 1);

            for(int i = 0; i<array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
