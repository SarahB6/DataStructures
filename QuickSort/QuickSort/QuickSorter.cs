using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    class QuickSorter<T>
        where T : IComparable<T>
    {
        public void QuickSortL(List<T> input, int left, int right)
        {
            if (right - left <= 0)
            {
                return;
            }

            int pivot = LomutoPartition(input, left, right);
            
            QuickSortL(input, left, pivot - 1);
            QuickSortL(input, pivot + 1, right);
            
        }

        public int LomutoPartition(List<T> input, int left, int right)
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

        public void QuickSortH(List<T> input, int left, int right)
        {
            if (right - left <= 0)
            {
                return;
            }

            int pivot = HoarePartition(input, left, right);

            QuickSortH(input, left, pivot);
            QuickSortH(input, pivot + 1, right);

        }

        public int HoarePartition(List<T> list, int left, int right)
        {
            T pivot = list[left];
            int low = left - 1;
            int high = right + 1;

            while (true)
            {
                do
                {
                    low++;
                } while (list[low].CompareTo(pivot) < 0);

                do
                {
                    high--;
                } while (list[high].CompareTo(pivot) > 0);

                if (low >= high)
                {
                    return high;
                }
                T temp = list[low];
                list[low] = list[high];
                list[high] = temp;
            }

        }
    }

}
