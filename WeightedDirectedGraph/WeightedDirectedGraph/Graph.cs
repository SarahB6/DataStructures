using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    public class Graph<T>
    {
        public List<Vertex<T>> Vertices;

        public List<Edge<T>> Edges { get; set; }
        public int VertexCount => Vertices.Count;
        public Graph()
        {
            Vertices = new List<Vertex<T>>();
            Edges = new List<Edge<T>>();
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
                for (int i = 0; i < Vertices.Count; i++)
                {
                    for(int a = 0; a < Vertices[i].Neighbors.Count; a++)
                    {
                        if(Vertices[i].Neighbors[a].EndingPoint.Equals(v))
                        {
                            Vertices[i].Neighbors.RemoveAt(a);
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
                Edges.Add(e);
                return true;
            }
            return false;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            Edge<T> e = new Edge<T>(a, b, distance);
            if (a!= null && b!= null)
            {
                for (int i = 0; i < a.Neighbors.Count; i++)
                {
                    if (a.Neighbors[i].EndingPoint.Equals(b))
                    { 
                        Edges.Remove(a.Neighbors[i]);
                        a.Neighbors.RemoveAt(i);
                       
                        return true;
                    }
                }    
                
            }
            return false;
        }
        public Vertex<T> Search(T value)
        {
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
