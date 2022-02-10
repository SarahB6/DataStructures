﻿using System;
using System.Collections.Generic;
using System.Text;

namespace makeLinkedListShoppingList
{
    class SinglyLinkedList<T>
    {
        public Node<T> head = null;
        public SinglyLinkedList()
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

                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
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
                while(current != given)
                {
                    if(current.next == given)
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
            else if(head.next == null)
            {
                head = null;
                return true;
            }
            else
            {
                Node<T> current = head;
                while(current.next.next != null)
                {
                    current = current.next;
                }
                current.next = null;
                return true;
            }
        }

        //remove all elements of the list
        public void Clear()
        {
            head = null;
        }

        //iterate through and check if the list contains a specific vale
        public bool Contains(T input)
        {
            if (head == null)
            {
                return false;
            }
            else
            {
                Node<T> current = head;
                while (current.next.next != null)
                {
                    return true;
                    /*
                    if(current.input.Equals(input))
                    {
                        return true;
                    }
                    */
                }
                return false;
            }

        }

        //Iterate and find the Node<T> that contains the specific value
        public void Search()
        {

        }

        //should return the number of elements in list
        public int Count()
        {
            int toReturn = 0;
            return toReturn;
        }

        public override string ToString()
        {
            //Loop through linked list, append to string, return string
            string toReturn = "";
            Node<T> current = head;
            while(current != null)
            {
                toReturn += $"{current.input}";
                if (current.next != null) toReturn += "->";
                current = current.next;
            }
            return toReturn;
        }
    }
}
