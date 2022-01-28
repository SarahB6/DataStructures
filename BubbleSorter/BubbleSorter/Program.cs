using System;
using System.Collections.Generic;

namespace BubbleSort
{
    class Program
    {
        public static void bubbleSort(List<int> input)
        {
            int count = 0;
            while (count < input.Count - 1)
            {
                count = 0;
                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        int currentInput = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = currentInput;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(3);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            bubbleSort(list);
            Console.WriteLine("\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
