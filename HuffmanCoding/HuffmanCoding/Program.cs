using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string toChange = "aaabaccedgherfvrjedaa";
            Console.WriteLine(toChange);
            HuffmanCode<charNode> hfc = new HuffmanCode<charNode>(toChange);
            Dictionary<char, int> dict = hfc.CalculateFrequencies();
            //hfc.checkIfAllInTree(dict);
            String s = hfc.compress();
            Console.WriteLine(s);
            string decomp = hfc.decompress(s);
            Console.WriteLine(decomp);
            Console.WriteLine(toChange.Equals(decomp));
        }
    }
}
