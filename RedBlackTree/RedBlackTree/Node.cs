using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class Node<T>
    where T:IComparable<T>
    {
        bool Red;
        T value;
        Node<T> leftChild;
        Node<T> rightChild;
        public Node(T val)
        {
            Red = true;
            value = val;
            
        }

        public Node<T> getLeft()
        {
            return leftChild;
        }

        public void setVal(T val)
        {
            value = val;
        }

        public T getVal()
        {
            return value;
        }

        public Node<T> getRight()
        {
            return rightChild;
        }
        public void setLeft(Node<T> left)
        {
            leftChild = left;
        }
        public void setRight(Node<T> right)
        {
            rightChild = right;
        }
        public bool IsRed()
        {
            return Red;
        }
        public void setRed(bool val)
        {
            Red = val;
        }

        public void switchRed()
        {
            if(Red)
            {
                Red = false;
            }
            else
            {
                Red = true;
            }
        }
    }
}
