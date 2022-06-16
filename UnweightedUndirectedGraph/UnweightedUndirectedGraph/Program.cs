using System;

namespace UnweightedUndirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> g = new Graph<int>();
            Vertex<int> v1 = new Vertex<int>(9);
            Vertex<int> v2 = new Vertex<int>(5);
            Vertex<int> v3 = new Vertex<int>(7);
            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddEdge(v1, v2);
            g.AddEdge(v1, v3);
            g.RemoveEdge(v1, v2);
            Vertex<int> a = g.Search(7);
        }
    }
}
