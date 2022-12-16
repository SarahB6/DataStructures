using System;
namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "a";
            string s2 = "b";
            string s3 = "c";
            string s4 = "d";
            string s5 = "e";
            string s6 = "f";
            string s7 = "g";
            string s8 = "h";
            string[] arr = new string[8] { s1, s2, s3, s4, s5, s6, s7, s8 };

            QuickUnion<string> qu = new QuickUnion<string>(arr);
            QuickFind<string> qf = new QuickFind<string>(arr);

            qu.Union(arr[2], arr[7]);
            qf.Union(arr[2], arr[7]);

            qu.Union(arr[0], arr[2]);
            qf.Union(arr[0], arr[2]);

            qu.Union(arr[0], arr[1]);
            qf.Union(arr[0], arr[1]);

            bool areConU = qu.AreConnected(arr[0], arr[7]);
            bool areConf = qf.AreConnected(arr[0], arr[7]);

            //qu.Union(arr[1], arr[7]);
            //qf.Union(arr[1], arr[7]);

            //qu.Union(arr[4], arr[5]);
            //qf.Union(arr[4], arr[5]);

            //qu.Union(arr[5], arr[6]);
            //qf.Union(arr[5], arr[6]);

            //qu.Union(arr[3], arr[5]);
            //qf.Union(arr[3], arr[5]);

            //qu.Union(arr[1], arr[5]);
            //qf.Union(arr[1], arr[5]);




        }
    }
}
