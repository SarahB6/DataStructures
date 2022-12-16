using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UnionFind
{
    public class QuickUnion<T>
    {

        private int[] parents;
        private Dictionary<T, int> map;

        public QuickUnion(IEnumerable<T> items)
        {
            int numCount = items.Count();
            int count = 0;
            parents = new int[numCount];
            map = new Dictionary<T, int>(numCount);

            foreach (T item in items)
            {
                map.Add(item, count);
                parents[count] = count;
                count++;
            }
        }

        public int Find(T p)
        {
            int a = map[p];
            while (parents[a] != a)
            {
                a = parents[a];
            }
            return a;
        }
        public bool Union(T p, T q)
        {
            if (AreConnected(p, q))
            {
                return false;
            }

            int rootP = Find(p);
            int rootQ = Find(q);
            parents[rootP] = rootQ;

            return true;
        }
        public bool AreConnected(T p, T q)
        {
            int a = Find(p);
            int b = Find(q);

            return a == b;
        }

    }
}
