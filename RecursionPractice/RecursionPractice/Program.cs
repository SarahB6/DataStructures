using System;

namespace RecursionPractice
{
    class Program
    {
        public static int sumOfElements(int[] array, int index)
        {
            if(index == array.Length-1)
            {
                return array[array.Length-1];
            }
            return array[index] + sumOfElements(array, index+1);
        }
        static void Main(string[] args)
        {
            int[] array = new int[4] { 1, 1, 1, 40 };
            Console.WriteLine(sumOfElements(array, 0));
        }
    }
}
