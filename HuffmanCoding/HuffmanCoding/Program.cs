using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string toChange = "afaacjdeigjdjckesi";

            HuffmanCode<charNode> hfc2 = new HuffmanCode<charNode>(toChange);
            Dictionary<char, int> dict = hfc2.CalculateFrequencies();
            byte[] arr = hfc2.compress();
            byte[] b = hfc2.FullBinary();

            byte[] together = new byte[arr.Length + b.Length];
            
            for(int i = 0; i<b.Length; i++)
            {
                together[i] = b[i];
            }

            for(int i = 0; i<arr.Length; i++)
            {
                together[b.Length+i] = arr[i];
            }

            

            HuffmanCode<charNode> hfc = new HuffmanCode<charNode>(toChange);
            Dictionary<char, int> dict2 = hfc.CalculateFrequencies();
            byte[] both = hfc.both();
            //byte[] arr = hfc.compress();
            //byte[] b = hfc.FullBinary();
            string returnString = hfc.decompress(both);

            for(int i = 0; i<together.Length; i++)
            {
                if(both[i+1] != together[i])
                {
                    Console.WriteLine("false");
                }
            }

        }
    }
}
