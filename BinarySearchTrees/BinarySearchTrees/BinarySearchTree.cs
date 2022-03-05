using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTrees
{
    class BinarySearchTree<T>
        where T : IComparable<T>
    {
        Node<T> root;
        int size = 0;
        public BinarySearchTree()
        {

        }

        public Node<T> search(T key)
        {
            Node<T> current = root;
            Node<T> keyNode = new Node<T>(key);
            if (current.value.Equals(key))
            {
                return root;
            }
            while(!current.value.Equals(key))
            {
                if (current.leftChild.value.Equals(key))
                {
                    return current.leftChild;
                }
                else if(current.rightChild.value.Equals(key))
                {
                    return current.rightChild;
                }
                else if(current.value.CompareTo(key) > 0)
                {
                    current = current.leftChild;
                }
                else if(current.value.CompareTo(key) < 0)
                {
                    current = current.rightChild;
                }
                else
                {
                    return current;
                }

            }
            if (current.value.CompareTo(key) < 0)
            {
                current.rightChild = keyNode;
                return current.rightChild;
            }
            else
            {
                current.leftChild = keyNode;
                return current.leftChild;
            }
        }

        public void minimum()
        {
            bool stillGoing = true;
            Node<T> current = root;
            while (stillGoing)
            {
                if (current.leftChild != null)
                {
                    current = current.leftChild;
                }
                else
                {
                    return;
                }
            }
        }

        public void maximum()
        {
            bool stillGoing = true;
            Node<T> current = root;
            while(stillGoing)
            {
                if(current.rightChild != null)
                {
                    current = current.rightChild;
                }
                else
                {
                    return;
                }
            }
        }

        public bool isLeftChild(Node<T> input)
        {
            if (input.parent == null)
            {
                return false;
            }
            return (input.parent.leftChild == input);
        }

        public bool isRightChild(Node<T> input)
        {
            if (input.parent == null)
            {
                return false;
            }
            return (input.parent.rightChild == input);
        }

        public void insert(T inputed)
        {
            Node<T> input = new Node<T>(inputed);
            if (root == null)
            {
                root = input;
                size++;
                return;
            }
            Node<T> current = root;
            bool stillGoing = true;
            while(stillGoing)
            {
                if (input.value.CompareTo(current.value) > 0)
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = input;
                        current.rightChild.parent = current;
                        size++;
                        return;
                    }
                    else
                    {
                        current = current.rightChild;
                    }
                }
                else if (input.value.CompareTo(current.value) < 0)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = input;
                        current.leftChild.parent = current;
                        size++;
                        return;
                    }
                    else
                    {
                        current = current.leftChild;
                    }
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = input;
                        current.rightChild.parent = current;
                        return;
                    }
                    else
                    {
                        current = current.rightChild;
                    }
                }


            }
            }

        public void delete(T input)
        {
            Node<T> node = search(input);
            Node<T> original = search(input);
            Node<T> current = node;
            if (node.Equals(root))
            {
                bool stillGoing = true;
                node = node.leftChild;
                while (stillGoing)
                {
                    if (node.rightChild != null)
                    {
                        current = node.rightChild;
                    }
                    else
                    {
                        original.value = node.value;
                        if (node.parent.rightChild.Equals(node))
                        {
                            node.parent.rightChild = null;
                        }
                        else
                        {
                            node.parent.leftChild = null;
                        }
                        size--;
                        break;
                    }
                }
            }
            else if (node.leftChild == null && node.rightChild == null)
            {
                size--;
                if (current.parent.leftChild.Equals(node))
                {
                    current.parent.leftChild = null;
                }
                else
                {
                    current.parent.rightChild = null;
                }
            }

            else if (node.leftChild == null && node.rightChild != null)
            {
                size--;
                node = node.leftChild;
            }
            else if (node.leftChild != null && node.rightChild == null)
            {
                size--;
                node = node.rightChild;
            }
            else
            {
                bool stillGoing = true;
                node = node.leftChild;
                while(stillGoing)
                {
                    if(node.rightChild != null)
                    {
                        current = node.rightChild;
                    }
                    else
                    {   original.value = node.value;
                        if(node.parent.rightChild.Equals(node))
                        {
                            node.parent.rightChild = null;
                        }
                        else
                        {
                            node.parent.leftChild = null;
                        }
                        size--;
                        break;
                    }
                }
               
            }
        }
    }
}
