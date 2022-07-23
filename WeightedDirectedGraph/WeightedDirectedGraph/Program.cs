using System;
using System.Collections.Generic;

namespace WeightedDirectedGraph
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Graph<int> g = new Graph<int>();
            Vertex<int> v1 = new Vertex<int>(1);
            Vertex<int> v2 = new Vertex<int>(2);
            Vertex<int> v3 = new Vertex<int>(3);
            Vertex<int> v4 = new Vertex<int>(4);
            Vertex<int> v5 = new Vertex<int>(5);
            Vertex<int> v6 = new Vertex<int>(6);
            Vertex<int> v7 = new Vertex<int>(7);
            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);
            g.AddVertex(v5);
            g.AddVertex(v6);
            g.AddVertex(v7);
            g.AddEdge(v1, v2, 9);
            g.AddEdge(v2, v4, 8);
            g.AddEdge(v3, v4, 1);
            Pathfinding<int> pathfinder = new Pathfinding<int>(g);
            List<int> list = pathfinder.DepthFirst(v1, v6);
        }
    }
}
