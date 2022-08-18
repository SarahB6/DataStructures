using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WeightedDirectedGraph
{
    class Program
    {
        public struct Point : IComparable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }

            public int CompareTo([AllowNull] Point other)
            {
                throw new NotImplementedException();
            }
        }
        static float Euclidean(Vertex<Point> node, Vertex<Point> goal)
        {
            float dx = Math.Abs(node.value.X - goal.value.X);
            float dy = Math.Abs(node.value.Y - goal.value.Y);
            float f = dx * dx + dy * dy;
            double d = (double)f;
            float fl = (float)(Math.Sqrt(d));
            return fl;
        }
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
            g.AddEdge(v1, v2, 100);
            g.AddEdge(v1, v3, 10);
            g.AddEdge(v2, v3, 1);
            g.AddEdge(v2, v4, 1);
            g.AddEdge(v3, v4, 1);
            g.AddEdge(v1, v6, 1);
            g.AddEdge(v6, v2, 1);
            Pathfinding<int> pathfinder = new Pathfinding<int>(g);
            List<int> list = pathfinder.DijkstraSearch(v1, v2);

            Point p1 = new Point();
            p1.X = 0;
            p1.Y = 0;
            Point p2 = new Point();
            p1.X = 2;
            p1.Y = 0;
            Point p3 = new Point();
            p1.X = 2;
            p1.Y = 2;
            Point p4 = new Point();
            p1.X = 3;
            p1.Y = 3;
            Point p5 = new Point();
            p1.X = 7;
            p1.Y = 0;
            Point p6 = new Point();
            p1.X = 20;
            p1.Y = 14;
            Graph<Point> p = new Graph<Point>();
            Vertex<Point> v1p = new Vertex<Point>(p1);
            Vertex<Point> v2p = new Vertex<Point>(p2);
            Vertex<Point> v3p = new Vertex<Point>(p3);
            Vertex<Point> v4p = new Vertex<Point>(p4);
            Vertex<Point> v5p = new Vertex<Point>(p5);
            Vertex<Point> v6p = new Vertex<Point>(p6);
            p.AddVertex(v1p);
            p.AddVertex(v2p);
            p.AddVertex(v3p);
            p.AddVertex(v4p);
            p.AddVertex(v5p);
            p.AddVertex(v6p);
            p.AddEdge(v1p, v2p, 100);
            p.AddEdge(v1p, v3p, 10);
            p.AddEdge(v2p, v3p, 1);
            p.AddEdge(v2p, v4p, 1);
            p.AddEdge(v3p, v4p, 1);
            p.AddEdge(v1p, v6p, 1);
            p.AddEdge(v6p, v2p, 1);
            Pathfinding<Point> pathfinder2 = new Pathfinding<Point>(p);
            List<Point> list2 = pathfinder2.A(v1p, v2p, Euclidean);
        }
    }
}
