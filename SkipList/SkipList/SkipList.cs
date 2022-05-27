using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class SkipList<T> : ICollection<T>
        where T : IComparable<T>
    {
        

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count => skipCount;

        public Node<T> head;
        private int skipCount = 0;
        public SkipList()
        {
            head = new Node<T>(default);
            head.height = 0;
        }
        Random rand = new Random();
        public int chooseRandomHeight()
        {
            int toReturn = 0;
            while (rand.Next(2) == 1 && toReturn <= head.height)
            {
                toReturn++;
            }
            if (toReturn > head.height)
            {
                Node<T> newHead = new Node<T>(default)
                {
                    height = toReturn,
                    down = head
                };
                head = newHead;
            }
            return toReturn;
        }


        public void Add(T item)
        {
            //Generate new height and handle resizing head
            int newHeight = chooseRandomHeight();

            //Move to right height
            Node<T> current = head;
            while (current.height > newHeight)
            {
                current = current.down;
            }

            //Pretend as if you are inserting into a doubly sorted linked list
            //Once you find the correct to spot to insert at CREATE the node with currentNode.height
            //Once you've sucessfully inserted (whether it was at the end or somewhere in the middle) move downward from the node to the left of the insertion
            //Put those two steps above into a loop until we reach an invalid height (-1)


            //For every level insert at each level
            Node<T> prev = null;
            while (current != null)
            {
                Node<T> toAdd = new Node<T>(item);
                toAdd.height = current.height;

                //Inserting at current level
                bool Inserted = false;
                while (!Inserted)
                {
                    if (current.right == null)
                    {
                        insertAtEnd(toAdd, current);
                        if (prev == null)
                        {
                            prev = toAdd;
                        }
                        else
                        {
                            prev.down = toAdd;
                            prev = prev.down;
                        }
                        Inserted = true;
                    }
                    else if (current.right.value.CompareTo(item) <= 0)
                    {
                        current = current.right;
                    }
                    else
                    {
                        insertInbetween(toAdd, current);
                        if (prev == null)
                        {
                            prev = toAdd;
                        }
                        else
                        {
                            prev.down = toAdd;
                            prev = prev.down;
                        }
                        Inserted = true;
                    }
                }
                current = current.down;

            }
            skipCount++;

        }

        public void insertInbetween(Node<T> toAdd, Node<T> before)
        {
            Node<T> after = before.right;

            toAdd.right = after;
            before.right = toAdd;
            after.left = toAdd;
            toAdd.left = before;
        }

        public void insertAtEnd(Node<T> toAdd, Node<T> before)
        {
            if (before.right == null)
            {
                before.right = toAdd;
                toAdd.left = before;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            List<T> toReturn = new List<T>();
            while (current.right != null)
            {
                toReturn.Add(current.value);
                current = current.right;
            }
            return (IEnumerator<T>)toReturn;
        }
        public bool Remove(T item)
        {
            Node<T> toRemove = Search(item);
            if (toRemove == head)
            {
                return false;
            }


            while (toRemove != null)
            {
                if (toRemove.right != null)
                {
                    toRemove.right.left = toRemove.left;
                    toRemove.left.right = toRemove.right;
                }
                else
                {
                    toRemove.left.right = null;
                }
                toRemove = toRemove.down;
            }
            return true;

        }

        public Node<T> Search(T item)
        {
            Node<T> current = head;
            while (current.down != null)
            {
                if(current.right == null)
                {
                    current = current.down;
                }
                else if(current.right.value.CompareTo(item) < 0)
                {
                    current = current.right;
                }
                else if (current.right.value.CompareTo(item) > 0)
                {
                    current = current.down;
                }
                else if(current.right.value.CompareTo(item) == 0)
                {
                    return current.right;
                }
                else
                {
                    return head;
                }
            }
            if (current.right.value.CompareTo(item) == 0)
            {
                return current.right;
            }
            else
            {
                return head;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
