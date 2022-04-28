using System;
using System.Collections.Generic;
using System.Text;

namespace AVLSearchTree
{
    class TreeData<T>
    {
        public T value;
        public int height;
        public int parentPos;
        public bool isLeft;
        public TreeData(T input, int height, bool isLeft, int parentPos)
        {
            value = input;
            this.height = height;
            this.isLeft = isLeft;
            this.parentPos = parentPos;
        }
    }
}
