using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class RedBlackTree<T>
    where T:IComparable<T>
    {
        Node<T> root;
        
        public void Add(T toAdd)
        {
            Node<T> newNode = new Node<T>(toAdd);
            if(root == null)
            {
                root = newNode;
            }
            else
            {
                root = addR(root, newNode);
            }

        }

        private Node<T> addR(Node<T> currentNode, Node<T> toAdd) 
        {
            if(currentNode.getLeft() == null && currentNode.getRight() == null)
            {
                if(currentNode.getVal().CompareTo(toAdd.getVal()) > 0)
                {
                    currentNode.setLeft(toAdd);
                }
                else
                {
                    currentNode.setRight(toAdd);
                }
                currentNode = Fixup(currentNode);
            }
            //write my base case can prob be the same if not similar to the avl tree one
            else
            {
                if(currentNode.getLeft().IsRed() && currentNode.getRight().IsRed())
                {
                    currentNode = FlipColor(currentNode);
                }
                currentNode = Fixup(currentNode);
                addR(currentNode.getLeft(), toAdd);
                addR(currentNode.getRight(), toAdd);

            }
            return currentNode;
        }
        
        private Node<T> FlipColor(Node<T> node)
        {
            if(node.getLeft() == null && node.getRight() == null)
            {
                node.switchRed();
            }
            else if(node.getLeft() == null)
            {
                node.switchRed();
                Node<T> rightNode = node.getRight();
                rightNode.switchRed();
                node.setRight(rightNode);
            }
            else if (node.getRight() == null)
            {
                node.switchRed();
                Node<T> leftNode = node.getLeft();
                leftNode.switchRed();
                node.setLeft(leftNode);
            }
            else
            {
                node.switchRed();
                Node<T> leftNode = node.getLeft();
                leftNode.switchRed();
                node.setLeft(leftNode);
                Node<T> rightNode = node.getRight();
                rightNode.switchRed();
                node.setLeft(rightNode);
            }
            return node;
        }
        public Node<T> RotateLeft(Node<T> node)
        {
            bool originalTopColor = node.IsRed();
            bool pivotColor = node.getRight().IsRed();
            Node<T> pivot = node.getRight();
            node.setRight(pivot.getLeft());
            pivot.setLeft(node);
            return pivot;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            bool originalTopColor = node.IsRed();
            bool pivotColor = node.getLeft().IsRed();
            Node<T> pivot = node.getLeft();
            node.setLeft(pivot.getRight());
            pivot.setRight(node);
            return pivot;
        }


        private void MoveRedRight(Node<T> currNode)
        {
            if(!currNode.getRight().IsRed() && !currNode.getRight().getLeft().IsRed() && !currNode.getRight().getRight().IsRed())
            {
                FlipColor(currNode);
                if(currNode.getLeft().getLeft().IsRed() || currNode.getLeft().getRight().IsRed())
                {
                    RotateLeft(currNode);

                    if (currNode.getRight().IsRed() && currNode.getRight().getRight().IsRed())
                    {
                        FlipColor(currNode);
                    }

                }
            }
        }

        private void MoveRedLeft(Node<T> currNode)
        {
            if (!currNode.getLeft().IsRed() && !currNode.getLeft().getLeft().IsRed() && !currNode.getLeft().getRight().IsRed())
            {
                FlipColor(currNode);
                if(currNode.getRight().getLeft().IsRed() || currNode.getRight().getRight().IsRed())
                {
                    MoveRedRight(currNode.getRight());
                    RotateLeft(currNode);
                    FlipColor(currNode);
                }
            }
        }

        public void Remove(T val) //write
        {
            Node<T> currNode = root;
            if(val.CompareTo(currNode.getVal()) < 0)
            {
                currNode = currNode.getLeft();
            }
        }

        private Node<T> Min(Node<T> node)
        {
            if (node.getLeft() == null) return node;
            return Min(node.getLeft());
        }

        private T RemoveR(Node<T> currNode, T val)
        {
            if(currNode ==  null)
            {
                throw new InvalidProgramException(); 
            }
            if(val.CompareTo(currNode.getVal()) < 0)
            {
                if(!currNode.getLeft().IsRed() && !currNode.getLeft().getLeft().IsRed())
                {
                    MoveRedLeft(currNode);
                }
                Fixup(currNode);
                RemoveR(currNode.getLeft(), val);
            }
            else
            {
                if(currNode.getLeft().IsRed())
                {
                    RotateRight(currNode);
                }
                if(currNode.getVal().CompareTo(val) == 0)
                {
                    if(currNode.getLeft() == null)
                    {
                        currNode.setRed(true);
                        currNode = null;
                        
                    }
                    else
                    {
                        Node<T> toChange = Min(currNode.getRight());
                        currNode.setVal(toChange.getVal());
                        Fixup(currNode);
                        RemoveR(currNode.getRight(), toChange.getVal());
                    }

                }
                else if(currNode.getVal().CompareTo(val) < 0)
                {
                    if(!currNode.getRight().getLeft().IsRed() && !currNode.getRight().getLeft().getLeft().IsRed())
                    {
                        MoveRedRight(currNode);
                    }
                    Fixup(currNode);
                    RemoveR(currNode.getRight(), val);
                }

            }
            return val;
        }

        private Node<T> Fixup(Node<T> node)
        {
            //First check if tree is left leaning
            if(node.getRight() != null && node.getLeft() != null && node.getRight().IsRed() && !node.getLeft().IsRed())
            {
                Node<T> p = RotateLeft(node);
                node = p;
            }
            //Second check if a 4 node is unbalanced
            if(node.getRight() != null && node.getLeft() != null && node.getLeft().IsRed() && node.getLeft().getLeft() != null && node.getLeft().getLeft().IsRed())
            {
                Node<T> p = RotateRight(node);
                node = p;
            }
            //Third break up four nodes by switiching the color
            if (node.getRight() != null && node.getLeft() != null && node.getLeft().IsRed() && node.getRight().IsRed())
            {
                FlipColor(node);
            }
            //Check if left child is a right leaning 3 node
            if (node.getRight() != null && node.getLeft() != null && node.getLeft().getRight().IsRed()&& !node.getLeft().getLeft().IsRed())
            {
                if (node.getRight().IsRed())
                {
                    Node<T> p = RotateLeft(node);
                    node = p;
                }
                //Second check if a 4 node is unbalanced
                if (node.getLeft().IsRed() && node.getLeft().getLeft().IsRed())
                {
                    Node<T> p = RotateRight(node);
                    node = p;
                }
            }
            return node;
        }
    }
}
