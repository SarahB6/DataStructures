using System;
using System.Collections.Generic;
using System.Text;

namespace QueueBackedByLinkedList
{
    class DoublyLinkedList<T>
    {
        public Node<T> head = null;
        public Node<T> tail = null;
        public DoublyLinkedList()
        {

        }

        public void AddFirst(T input)
        {
            Node<T> toAdd = new Node<T>(input);
            if (head != null)
            {
                toAdd.next = head;
            }

            head = toAdd;
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            tail = current;


        }

        public void AddLast(T input)
        {
            if (head == null)
            {
                AddFirst(input);
            }
            else
            {
                Node<T> toAdd = new Node<T>(input);
                tail.next = toAdd;

            }
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            tail = current;
        }

        //insert the given value before the given Node<T>
        public void AddBefore(T input, Node<T> given)
        {
            if (head == null)
            {
                Node<T> head = new Node<T>(input);

                head.next = null;
            }
            else
            {
                Node<T> toAdd = new Node<T>(input);

                Node<T> current = head;
                if (current == given)
                {
                    AddFirst(input);
                }
                while (current != given)
                {
                    if (current.next == given)
                    {
                        current.next = toAdd;
                        toAdd.next = given;
                    }
                    current = current.next;
                }
            }
        }

        //insert the given value after the given Node<T>
        public void AddAfter(T input, Node<T> given)
        {
            if (head == null)
            {
                Node<T> head = new Node<T>(input);

                head.next = null;
            }
            else
            {
                Node<T> toAdd = new Node<T>(input);

                Node<T> current = head;
                while (current.next != null)
                {
                    if (current == given)
                    {
                        toAdd.next = current.next;
                        current.next = toAdd;

                    }
                    current = current.next;
                }
            }
        }

        //if the list is empty return false
        //otherwise shift everything back one and return true
        public bool RemoveFirst()
        {
            if (head == null)
            {
                return false;
            }
            else
            {
                Node<T> current = head;
                head = current.next;
                return true;
            }
        }

        //if the list is empty return false
        //"cut off" the tail of the original list
        public bool RemoveLast()
        {
            if (head == null)
            {
                return false;
            }
            else if (head.next == null)
            {
                head = null;
                return true;
            }
            else
            {
                Node<T> current = head;
                while (current.next.next != null)
                {
                    current = current.next;
                }
                current.next = null;
                return true;
            }
        }

        public void Remove(Node<T> given)
        {
            Node<T> current = head;
            if (head.Equals(given))
            {
                RemoveFirst();
            }
            else
            {
                while (current.next.next != null)
                {
                    if (current.next.Equals(given))
                    {
                        current.next = current.next.next;
                        break;
                    }
                    current = current.next;
                }
                if (current.next.Equals(given))
                {
                    current.next = current.next.next;
                }
            }
        }

        //remove all elements of the list
        public void Clear()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return (head == null);
        }

        //should return the number of elements in list
        public int Count()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                Node<T> current = head;
                while (current.next != null)
                {
                    count++;
                    current = current.next;

                }
                return count + 1;
            }
        }

        public int index(T given)
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                Node<T> current = head;
                while (current.next != null)
                {
                    if (current.input.Equals(given))
                    {
                        return count;
                    }
                    count++;
                    current = current.next;

                }
                return count + 1;
            }
        }

        public T outputAtIndex(int ind)
        {
            int count = 0;
            Node<T> current = head;
            while (current.next != null)
            {
                if (index(current.input).Equals(ind))
                {
                    return current.input;
                }
                count++;
                current = current.next;


            }
            return current.input;
        }



        //Loop through linked list, append to string, return string
        public override string ToString()
        {
            //Loop through linked list, append to string, return string
            string toReturn = "";
            Node<T> current = head;
            while (current != null)
            {
                toReturn += $"{current.input}";
                if (current.next != null) toReturn += "->";
                current = current.next;
            }
            return toReturn;
        }
    }
}
