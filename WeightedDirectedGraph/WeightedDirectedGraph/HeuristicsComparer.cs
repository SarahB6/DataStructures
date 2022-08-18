using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class HeursticsComparer<T>
    where T : IComparable<T>
    {
        public static int Compare(Vertex<T> v1, Vertex<T> v2)
        {
            return v1.finalDistance.CompareTo(v2.finalDistance);
        }
    }
}
