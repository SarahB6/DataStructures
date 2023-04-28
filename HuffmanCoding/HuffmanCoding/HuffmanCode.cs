using System;
using System.Collections.Generic;
using System.Text;
using HuffmanCoding;

namespace HuffmanCoding
{
    class HuffmanCode<T>
        where T : IComparable<T>
    {
        heap<charNode> pqueue;
        string s;
        char[] ch;
        charNode root;
        Dictionary<char, string> map;
        StringBuilder finalAsString;

        public HuffmanCode(string s)
        {
            finalAsString = new StringBuilder();
            map = new Dictionary<char, string>();
            this.s = s;
            pqueue = new heap<charNode>();
            ch = s.ToCharArray();
        }

        public Dictionary<char, int> CalculateFrequencies()
        {
            char[] stringInChar = s.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                int v = 0;
                if (dict.TryGetValue(stringInChar[i], out v))
                {
                    dict[stringInChar[i]] = v + 1;
                }
                else
                {
                    dict.Add(stringInChar[i], 1);
                }
            }
            return dict;
        }

        public void checkIfAllInTree(Dictionary<char, int> dict)
        {
            //consider if dict size is 1
            foreach (KeyValuePair<char, int> pair in dict)
            {
                charNode node = new charNode(pair.Value, pair.Key);
                pqueue.Insert(node);
            }
        }

        private void putInTree(Dictionary<char, int> dict)
        {
            //consider if dict size is 1
            foreach (KeyValuePair<char, int> pair in dict)
            {
                charNode node = new charNode(pair.Value, pair.Key);
                pqueue.Insert(node);
            }
            makeOne();
        }

        private void makeOne()
        {
            while (pqueue.size() > 1)
            {
                charNode first = pqueue.Pop();
                charNode second = pqueue.Pop();
                charNode parent = new charNode((first.intValue() + second.intValue()), '$');
                if (first.intValue() > second.intValue())
                {
                    parent.setRightChild(first);
                    parent.setLeftChild(second);
                }
                else
                {
                    parent.setRightChild(second);
                    parent.setLeftChild(first);
                }
                pqueue.Insert(parent);

            }
            root = pqueue.getRoot();
        }

        public byte[] compress()
        {
            compresser();
            return originalAsByte();
        }

        public string compresser()
        {
            char val = ch[0];
            bool allSame = true;
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] != val)
                {
                    allSame = false;
                }
            }
            StringBuilder sb = new StringBuilder();
            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> dict = CalculateFrequencies();
            putInTree(dict);
            if (allSame)
            {
                string str = "";
                for (int i = 0; i < ch.Length; i++)
                {
                    str += "1";
                }
                return str;
            }

            return compressOriginal(ch, root);

        }

        public byte[] originalAsByte()
        {
            string codeAsString = finalAsString.ToString();
            List<byte> byteList = new List<byte>();
            int numberOfZeros = 8 - codeAsString.Length % 8;
            for (int i = 0; i < numberOfZeros; i++)
            {
                finalAsString.Append("0");
            }
            codeAsString = finalAsString.ToString();
            for (int i = 0; i < codeAsString.Length / 8; i++)
            {
                string current8 = codeAsString.Substring(8 * i, 8);
                byte b = Convert.ToByte(current8, 2);
                byteList.Add(b);
            }
            byteList.Add((byte)numberOfZeros);
            return byteList.ToArray();
        }

        public string compressOriginal(char[] ch, charNode root)
        {
            StringBuilder sb = new StringBuilder();
            string st = "";
            //make a map where each thing in my hashmap starting from root becomes binary (left is 0 right is 1)
            addBinary(st, root);
            StringBuilder sbToReturn = new StringBuilder();
            for (int i = 0; i < ch.Length; i++)
            {
                sbToReturn.Append(map[ch[i]]);
            }
            finalAsString = sbToReturn;
            return sbToReturn.ToString();

        }

        private void addBinary(string st, charNode curr)
        {
            if (curr.getLeft() == null)
            {
                map.Add(curr.charValue(), st);
                return;
            }
            else
            {
                addBinary(st + "0", curr.getLeft());
                addBinary(st + "1", curr.getRight());
            }
        }

        public string asString(byte[] inByte)
        {
            StringBuilder building = new StringBuilder();
            int numOfZeros = inByte[inByte.Length - 1];
            for (int i = 0; i < inByte.Length - 1; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Convert.ToString(inByte[i], 2));
                StringBuilder sb2 = new StringBuilder();
                int counter = sb.Length;
                while (counter % 8 != 0)
                {
                    sb2.Append(0);
                    counter++;
                }
                sb2.Append(sb);
                building.Append(sb2);
            }
            building.Remove(building.Length - numOfZeros, numOfZeros);
            return building.ToString();
        }

        public string decompress(byte[] inByte)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder toReturn = new StringBuilder();
            string inBin = asString(inByte);
            charNode toUse = root;
            if (root.getLeft() == null && root.getRight() == null)
            {
                for (int i = 0; i < inBin.Length; i++)
                {
                    toReturn.Append(root.charValue());
                }
            }
            else
            {
                for (int i = 0; i < inBin.Length; i++)
                {
                    if (inBin[i] == '0')
                    {
                        toUse = toUse.getLeft();
                    }
                    else
                    {
                        toUse = toUse.getRight();
                    }
                    if (toUse.getLeft() == null && toUse.getRight() == null)
                    {
                        toReturn.Append(toUse.charValue());
                        toUse = root;
                    }


                }
            }
            return toReturn.ToString();
        }


    }
}
