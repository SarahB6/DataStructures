using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    public class Vertex<T>
    {
        public T value { get; set; }
        public List<Vertex<T>> Neighbors { get; set; }

        public int GetNeighborCount()
        {
            return Neighbors.Count;
        }

        public Vertex(T value) 
        {
            this.value = value;
            Neighbors = new List<Vertex<T>>();
        }

       
    }
}
