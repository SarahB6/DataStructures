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
        Dictionary<char, byte[]> byteMap;
        

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

        public KeyValuePair<char, bool>[] treeAsArray()
        {
            List<KeyValuePair<char, bool>> list = new List<KeyValuePair<char, bool>>();
           
            Queue<charNode> q = new Queue<charNode>();
            int i = 0;
            q.Enqueue(root);
            while(q.Count != 0)
            {
                charNode cn = q.Dequeue();
                KeyValuePair<char, bool> curr = new KeyValuePair<char, bool>(cn.charValue(), cn.charValue()=='$');
                list.Add(curr);
                i++;
                if(cn.getLeft()!=null)
                {
                    q.Enqueue(cn.getLeft());
                }
                if(cn.getRight()!=null)
                {
                    q.Enqueue(cn.getRight());
                }
            }
            KeyValuePair<char, bool>[] toReturn = list.ToArray();
            
            return toReturn;
        }

        public string FullBinary()
        {
            StringBuilder sb = new StringBuilder();
            KeyValuePair<char, bool>[] treeArr = treeAsArray();
            int a = treeArr.Length;
            List<byte> list = new List<byte>();
            list.Add((byte)a);
            for(int i = 0; i<a; i++)
            {
                char currentChar = treeArr[i].Key;
                bool currentBool = treeArr[i].Value;

                list.Add(currentBool);
                list.Add((byte)currentChar);
                
            }

            return sb.ToString();
        }

        public charNode getRoot()
        {
            return root;
        }

        public charNode ArrayToTree(KeyValuePair<char, bool>[] asArray)
        {
            charNode thisRoot = new charNode(0, asArray[0].Key);
            charNode curr = thisRoot;
            Queue<charNode> q = new Queue<charNode>();
            int currInt = 0;
            q.Enqueue(curr);
            while(q.Count != 0)
            {
                curr = q.Dequeue();
                charNode left = new charNode(0, asArray[currInt + 1].Key);
                charNode right = new charNode(0, asArray[currInt + 2].Key);
                if (asArray[currInt + 1].Key == '$')
                {
                    q.Enqueue(left);
                   
                }
                if (asArray[currInt + 2].Key == '$')
                {
                    q.Enqueue(right);
                }
                currInt+=2;
                curr.setLeftChild(left);
                curr.setRightChild(right);
                    
            }
            return thisRoot;
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
            
            
            
            
            return compressOriginalAsString(ch, root);
            
        }

        public byte[] compressOriginalAsByte(char[] ch, charNode root)
        {
            List<byte> byteList = new List<byte>();
            // have 2 bytes store my first number (like the number of chars)
            uint num = (uint)ch.Length;
            KeyValuePair<char, bool>[] treeArr = treeAsArray();
            for(int i = 0; i<ch.Length; i++)
            {
                
            }

            
        }

        public string compressOriginalAsString(char[] ch, charNode root)
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
