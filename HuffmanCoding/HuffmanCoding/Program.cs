using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string toChange = "afaacjdeigjdjckesi";

            HuffmanCode<charNode> hfc = new HuffmanCode<charNode>(toChange);
            Dictionary<char, int> dict = hfc.CalculateFrequencies();
            byte[] arr = hfc.compress();
            string returnString = hfc.decompress(arr);

        }
    }
}
