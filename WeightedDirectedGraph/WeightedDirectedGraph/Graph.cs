using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class Graph<T>
    {
        private List<Vertex<T>> Vertices;

        public IReadOnlyList<Vertex<T>> vertices => Vertices;
        public IReadOnlyList<Edge<T>> Edges { get; set; }
        public int VertexCount => Vertices.Count;
        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> v)
        {
            if (v != null && v.GetNeighborCount() == 0 && !Vertices.Contains(v))
            {
                Vertices.Add(v);
            }
        }

        public bool RemoveVertex(Vertex<T> v)
        {
            if (v != null)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    for(int a = 0; a < vertices[i].Neighbors.Count; a++)
                    {
                        if(vertices[i].Neighbors[a].EndingPoint.Equals(v))
                        {
                            vertices[i].Neighbors.RemoveAt(a);
                        }
                    }
                }
                v.Neighbors.Clear();
                Vertices.Remove(v);
                return true;
            }
            return false;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            Edge<T> e = new Edge<T>(a, b, distance);
            if (a != null && b != null && Vertices.Contains(a) && Vertices.Contains(b) && !a.Neighbors.Contains(e))
            {
                a.Neighbors.Add(e);
            }
            return false;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            Edge<T> e = new Edge<T>(a, b, distance);
            if (a!= null && b!= null && a.Neighbors.Contains(e))
            {
                a.Neighbors.Remove(e);
                return true;
            }
            return false;
        }
        public Vertex<T> Search(T value)
        {
            int val = -1;
            for (int i = 0; i < VertexCount; i++)
            {
                if (Vertices[i].value.Equals(value))
                {
                    return Vertices[i];
                }
            }
            return default;
        }
        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            Edge<T> e = new Edge<T>(a, b, distance);
            if(a != null && b != null && a.Neighbors.Contains(e))
            {
                return e;
            }
            return default;
        }
    }
}
