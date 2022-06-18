using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class Vertex<T>
    {
        public T value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

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
