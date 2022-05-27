using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class Program
    {
        public static string linePrint(Node<int> current, int rowNum, List<int> toCheck)
        {
            string s = "H ";
            int i = 1;
            while (current.right != null)
            {
                if (current.right.value == toCheck[i])
                {
                    s += $"--> {current.right.value}";
                    current = current.right;
                    
                }
                else
                {
                    string a = "";
                    if(toCheck[i] < 10)
                    {
                        a = " ";
                    }
                    else if(toCheck[i]< 100)
                    {
                        a = "  ";
                    }
                    else
                    {
                        a = "   ";
                    }
                    s += $"    {a}";
                }i++;
            }
            return s;
        }

        public static void totalPrint(SkipList<int> list)
        {
            Node<int> current = list.head;
            List<int> l = map(list);
            for (int i = list.head.height; i>= 0; i--)
            {
                string result = linePrint(current, i, l);
                current = current.down;
                Console.WriteLine(result);
            }
            
        }

        public static List<int> map(SkipList<int> list)
        {
            Node<int> current = list.head;
            List<int> thisList = new List<int>();
            while(current.down != null)
            {
                current = current.down;
            }
            while(current.right != null)
            {
                thisList.Add(current.value);
                current = current.right;
            }
            thisList.Add(current.value);
            return thisList;

        }

        static void Main(string[] args)
        {
            SkipList<int> list = new SkipList<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(1, 10));
            }
            totalPrint(list);
            Console.WriteLine("____________________________________________");
            list.Remove(3);
            totalPrint(list);
        }
    }
}
