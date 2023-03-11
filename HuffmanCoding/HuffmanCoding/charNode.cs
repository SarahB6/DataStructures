using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCoding
{
    class charNode : IComparable<charNode>

    {
        charNode p;
        charNode rightChild;
        charNode leftChild;
        int v;
        char c;

        public charNode(int intValue, char charVal)
        {
            v = intValue;
            c = charVal;
        }

        public int intValue()
        {
            return v;
        }

        public char charValue()
        {
            return c;
        }

        public void setRightChild(charNode rc)
        {
            rightChild = rc;
        }

        public charNode getRight()
        {
            return rightChild;
        }

        public void setLeftChild(charNode lc)
        {
            leftChild = lc;
        }

        public charNode getLeft()
        {
            return leftChild;
        }

        public int CompareTo(charNode obj)
        {
            return (v - obj.intValue());
        }
    }
}
