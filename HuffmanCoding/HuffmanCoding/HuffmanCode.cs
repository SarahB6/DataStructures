using System;
using System.Collections.Generic;
using System.Text;
using HuffmanCoding;

namespace HuffmanCoding
{
    class HuffmanCode<T>
        where T: IComparable<T>
    {
        heap<charNode> pqueue;
        string s;
        char[] ch;
        charNode root;
        Dictionary<char, string> map;

        public HuffmanCode(string s)
        {
            map = new Dictionary<char, string>();
            this.s = s;
            pqueue = new heap<charNode>();
            ch = s.ToCharArray();
        }

        public Dictionary<char, int> CalculateFrequencies()
        {
            char[] stringInChar = s.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for(int i = 0; i<s.Length; i++)
            {
                int v = 0;
                if(dict.TryGetValue(stringInChar[i], out v))
                {
                    dict[stringInChar[i]] = v+1;
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
            foreach(KeyValuePair<char, int> pair in dict)
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
                if(first.intValue() > second.intValue())
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

        public string compress()
        {
            char val = ch[0];
            bool allSame = true;
            for(int i = 0; i<ch.Length; i++)
            {
                if(ch[i] != val)
                {
                    allSame = false;
                }
            }
            StringBuilder sb = new StringBuilder();
            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> dict = CalculateFrequencies();
            putInTree(dict);
            if(allSame)
            {
                string str = "";
                for(int i = 0; i<ch.Length; i++)
                {
                    str += "1";
                }
                return str;
            }
            
            
            
            
            return compressOriginal(ch, root);
            
        }

        public string compressOriginal(char[] ch, charNode root)
        {// val is 111110000
            StringBuilder sb = new StringBuilder();
            string st = "";
            //make a map where each thing in my hashmap starting from root becomes binary (left is 0 right is 1)
            addBinary(st, root);
            StringBuilder sbToReturn = new StringBuilder();
            for(int i = 0; i<ch.Length; i++)
            {
                sbToReturn.Append(map[ch[i]]);
            }
            return sbToReturn.ToString();

        }

        private void addBinary(string st, charNode curr)
        {
            if(curr.getLeft() == null)
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

        public string decompress(string inBin)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder toReturn = new StringBuilder();
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
