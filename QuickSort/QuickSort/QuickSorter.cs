using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    class QuickSorter<T>
        where T : IComparable<T>
    {
        public void QuickSort(List<T> input, int left, int right)
        {
            if (right - left <= 0)
            {
                return;
            }

            int pivot = Partition(input, left, right);
            
            QuickSort(input, left, pivot - 1);
            QuickSort(input, pivot + 1, right);
            
        }

        public int Partition(List<T> input, int left, int right)
        {
            T pivotValue = input[right];
            int wall = left-1;
            for(int i = 0; i<right-left; i++)
            {
                
                if(input[left+i].CompareTo(pivotValue) < 0)
                {
                    wall++;
                    T val = input[left + i];
                    input[left + i] = input[wall];
                    input[wall] = val;
                    
                }
            }
            input[right] = input[wall+1];
            input[wall+1] = pivotValue;
            return wall+1;
        }

    }
}
