using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class Vertex<T> : IComparable<Vertex<T>>
    where T : IComparable<T>
    {
        IComparer<T> comparer;
        public Vertex(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int CompareTo(Vertex<T> v)
        {
            float d = knownDistance - v.knownDistance;
            return (int)d;
        }


        public T value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public bool visited = false;

        public float knownDistance = float.PositiveInfinity;

        public float finalDistance = float.PositiveInfinity;

        public Vertex<T> founder;

        public int GetNeighborCount()
        {
            return Neighbors.Count;
        }

        public Vertex(T value)
        {
            this.value = value;
            Neighbors = new List<Edge<T>>();
        }


    }
}
