using System;
using System.Collections.Generic;
using System.Text;

namespace AVLSearchTree
{
    class Node<T>
    {
        public T value;
        public Node<T> leftChild;
        public Node<T> rightChild;

        public int ChildCount
            => (leftChild == null ? 0 : 1) + (rightChild == null ? 0 : 1);

        public Node<T> First
        {
            get
            {
                if (leftChild == null && rightChild != null)
                {
                    return rightChild;
                }
                if (leftChild != null)
                {
                    return leftChild;
                }
                return null;
            }
        }

        public int Height => GetHeight(this);

        public Node(T value)
        {
            this.value = value;
        }

        public int GetBalance()
        {
            int leftHeight = rightChild == null ? 0 : rightChild.Height;
            int rightHeight = leftChild == null ? 0 : leftChild.Height;
            return rightHeight - leftHeight;
        }

        private int GetHeight(Node<T> node) //can make better by just maintaining the height
        {
            if (node is null) return 0;
            if (node.leftChild == null && node.rightChild == null) return 1;

            int leftHeight = 1 + GetHeight(node.leftChild);
            int rightHeight = 1 + GetHeight(node.rightChild);

            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }

    }
}

