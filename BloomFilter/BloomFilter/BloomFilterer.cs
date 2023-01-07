using System;
using System.Collections.Generic;

namespace BloomFilter
{
    public class BloomFilterer<T>
    {
        bool[] arr;
        int arrSize;
        List<Func<T, int>> funcList;
        public BloomFilterer(int cap, Func<T, int>[] hashFuncs)
        {
            arr = new bool[cap];
            arrSize = cap;
            funcList = new List<Func<T, int>>();
            for (int i = 0; i < hashFuncs.Length; i++)
            {
                funcList.Add(hashFuncs[i]);
            }
            funcList.Add(HashFuncOne);
            funcList.Add(HashFuncTwo);
            funcList.Add(HashFuncThree);
        }

        public void Insert(T item)
        {
            foreach (Func<T, int> curr in funcList)
            {
                arr[curr(item)] = true;
            }
        }
        public bool ProbablyContains(T item)
        {
        foreach (Func<T, int> curr in funcList)
        {
            if (!arr[curr(item)])
            {
                return false;
            }
        }
        return true;
        }

        private int HashFuncOne(T item)
        {
            int val = item.GetHashCode();
            return val%arrSize;
        }

        private int HashFuncTwo(T item)
        {
            int val = item.GetHashCode();
        return (val * 2)%arrSize;
        }

        private int HashFuncThree(T item)
        {
            int val = item.GetHashCode();
        return (val * 3)%arrSize;
        }
    }
}
