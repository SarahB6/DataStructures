using System;

namespace WeightedDirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> g = new Graph<int>();
            Vertex<int> v1 = new Vertex<int>(7);
            Vertex<int> v2 = new Vertex<int>(3);
            Vertex<int> v3 = new Vertex<int>(12);
            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddEdge(v1, v2, 9);
            g.AddEdge(v2, v3, 8);
            g.RemoveVertex(v1);
        }
    }
}
