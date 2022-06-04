using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    public class TrieNode
    {
        public TrieNode leftChild;
        public TrieNode rightChild;
        public char Letter { get; private set; }
        public Dictionary <char, TrieNode> Children { get; private set; }
        public bool IsWord { get; set; }

        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }
}
