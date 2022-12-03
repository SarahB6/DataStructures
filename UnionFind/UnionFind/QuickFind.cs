using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFind
{
    public class QuickFind<T>
    {

        private int[] sets;
        private Dictionary<T, int> map;

        public QuickFind(IEnumerable<T> items)
        {
            
            map = new Dictionary<T, int>(items.Count());
            sets = new int[items.Count()];
            int count = 0;
            foreach(T item in items)
            {
                map.Add(item, count);
                count++;
            }
            for(int i = 0; i<items.Count(); i++)
            {
                sets[i] = i;
            }
        }

        public int Find(T p) => sets[map[p]];

        public bool Union(T p, T q)
        {
            if(AreConnected(p,q))
            {
                return false;
            }
            int val1 = sets[map[p]];
            int val2 = sets[map[q]];
            if(val1>val2)
            {
                for(int i = 0; i<sets.Length; i++)
                {
                    if(sets[i] == val1)
                    {
                        sets[i] = val2;
                    }
                }
            }
            else
            {
                for (int i = 0; i < sets.Length; i++)
                {
                    if (sets[i] == val2)
                    {
                        sets[i] = val1;
                    }
                }
            }
            return true;
        }

        public bool AreConnected(T p, T q)
        {
            if(sets[map[p]] == sets[map[q]])
            {
                return true;
            }
            return false;

        }

    }
}
