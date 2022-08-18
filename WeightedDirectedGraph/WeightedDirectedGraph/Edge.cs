using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class Edge<T>
    where T : IComparable<T>
    {
        IComparer<T> comparer;
        public Edge(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndingPoint { get; set; }
        public float Distance { get; set; }

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }
    }
}
