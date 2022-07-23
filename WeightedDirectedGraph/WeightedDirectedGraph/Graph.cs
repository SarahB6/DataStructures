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
                            for (int b = 0; b < Edges.Count; b++)
                            {
                                if (Edges[b].StartingPoint.Equals(Vertices[i]))
                                {
                                    RemoveEdge(Vertices[i], v);
                                }
                            }
                            
                        }
                    }
                }
                for(int b = 0; b<v.Neighbors.Count; b++)
                {
                        RemoveEdge(v, v.Neighbors[b].EndingPoint);
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

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a!= null && b!= null)
            {
                for (int c = 0; c < Edges.Count; c++)
                {
                    for (int i = 0; i < a.Neighbors.Count; i++)
                    {
                        if (a.Neighbors[i].Equals(Edges[c]))
                        {
                            Edges.Remove(Edges[c]);
                            a.Neighbors.RemoveAt(i);

                            return true;
                        }
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
        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null)
            {
                for (int c = 0; c < Edges.Count; c++)
                {
                    for (int i = 0; i < a.Neighbors.Count; i++)
                    {
                        if (a.Neighbors[i].Equals(Edges[c]))
                        {
                            return Edges[c];
                        }
                    }
                }

            }
            return default;
        }
    } 
}
