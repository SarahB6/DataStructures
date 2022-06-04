using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    class Trie
    {
        TrieNode head =  new TrieNode('!');
        public void Clear()
        {
            head.Children.Clear();
        }

        public void Insert(string word)
        {
            TrieNode current = head;
            foreach(char c in word)
            {
               
                if(!current.Children.ContainsKey(c))
                {  
                    TrieNode n = new TrieNode(c);
                    current.Children.Add(c, n);
                }
                current = current.Children[c];
            }
            current.IsWord = true;
        }

        public bool Contains(string word)
        {
            TrieNode current = head;
            foreach(char c in word)
            {
                if(current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    return false;
                }
            }
            return current.IsWord;
        }

        private TrieNode SearchNode(string word)
        {
            List<string> toReturn = new List<string>();
            TrieNode current = head;
            foreach (char c in word)
            {
                if (current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
            }
            return current;
        }


        public List<string> GetAllMatchingPrefix(string prefix)
        {
            List<string> toReturn = new List<string>();
            TrieNode end = SearchNode(prefix);
            foreach ((char c, TrieNode node) in end.Children)
            {
                if (node.IsWord)
                {
                    toReturn.Add(prefix+c);
                }
                List<string> smaller = GetAllMatchingPrefix(prefix + c);
                foreach(string s in smaller)
                {
                    toReturn.Add(s);
                }
            }
            return toReturn;
        }

        public bool Remove(string prefix)
        {
            TrieNode current = head;
            foreach(char c in prefix)
            {
                if(current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    return false;
                }
            }
            current.IsWord = false;
            return true;
        }
    }
}
