using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string toChange = "aabccdeff";
            Console.WriteLine(toChange);
            HuffmanCode<charNode> hfc = new HuffmanCode<charNode>(toChange);
            Dictionary<char, int> dict = hfc.CalculateFrequencies();
            String s = hfc.compress();
            Console.WriteLine(s);
            string decomp = hfc.decompress(s);
            Console.WriteLine(decomp);
            Console.WriteLine(toChange.Equals(decomp));
            KeyValuePair<char, bool>[] pairs = hfc.treeAsArray();
            charNode realRoot = hfc.getRoot();
            charNode root = hfc.ArrayToTree(pairs);
            Console.WriteLine(realRoot);
        }
    }
}
