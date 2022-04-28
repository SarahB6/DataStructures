using System;
using System.Collections.Generic;
using System.Text;

namespace AVLSearchTree
{
    class AVLSearchTree<T>
    where T : IComparable<T>
    {
        Node<T> root;
        int count = 0;
        public void Insert(T value)
        {
            root = insert(root, value);
        }

        public Node<T> GetRoot()
        {
            return root;
        }
        private Node<T> insert(Node<T> current, T value)
        {
            if (current == null)
            {
                count++;
                Node<T> toReturn = new Node<T>(value);
                return toReturn;
            }
            if (current.value.CompareTo(value) > 0)
            {
                current.leftChild = insert(current.leftChild, value);
            }
            else
            {
                current.rightChild = insert(current.rightChild, value);
            }

            return Balance(current);
        }
                
        private Node<T> Balance(Node<T> node)
        {
            int balance = node.GetBalance();
            if(balance > 1)
            {
                if (node.leftChild.GetBalance() <= -1)
                {
                    node.leftChild = RotateLeft(node.leftChild);
                }
                node = RotateRight(node);
            }
            else if(balance < -1)
            {
                if(node.rightChild.GetBalance() >= 1)
                {
                    node.rightChild = RotateRight(node.rightChild);
                }
                node = RotateLeft(node);
            }
            return node;
        }
        public Node<T> RotateLeft(Node<T> node)
        {
            Node<T> pivot = node.rightChild;
            node.rightChild = pivot.leftChild;
            pivot.leftChild = node;
            return pivot;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            Node<T> pivot = node.leftChild;
            node.leftChild = pivot.rightChild;
            pivot.rightChild = node;
            return pivot;
        }


        public bool Delete(T input)
        {
            int oldCount = count;
            root = delete(root, input);
            return oldCount < count;
        }
        
        private Node<T> Max(Node<T> node)
        {
            if (node.rightChild == null) return node;
            return Max(node.rightChild);
        }

        private Node<T> delete(Node<T> current, T val)
        {
            if(current == null)
            {
                return null;
            }

            if(current.value.CompareTo(val) == 0)
            {
                if(current.ChildCount == 2)
                {
                    Node<T> newNodeToKill = Max(current.leftChild);
                    current.value = newNodeToKill.value;
                    current.leftChild = delete(current.leftChild, newNodeToKill.value);
                }
                else
                {
                    count--;
                    return current.First;
                }
            }
            else if (current.value.CompareTo(val) > 0)
            {
                current.leftChild = delete(current.leftChild, val);
            }
            else if( current.value.CompareTo(val) < 0)
            {
                current.rightChild = delete(current.rightChild, val);
            }
            return Balance(current);

        }


    }
}
