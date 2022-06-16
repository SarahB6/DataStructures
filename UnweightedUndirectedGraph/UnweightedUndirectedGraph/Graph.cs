using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    public class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

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
            if(Vertices.Contains(v))
            {
                
                for(int i = 0; i<v.Neighbors.Count; i++)
                {
                    v.Neighbors[i].Neighbors.Remove(v);
                }
                v.Neighbors.Clear();

                Vertices.Remove(v);
                return true;
            }
            return false;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if(a != null && b != null && Vertices.Contains(a) && Vertices.Contains(b))
            {
                addNeighbor(a, b);
                addNeighbor(b, a);
                return true;
            }
            return false;
        }

        private void addNeighbor(Vertex<T> a, Vertex<T> b)
        {
            List<Vertex<T>> l1 = new List<Vertex<T>>();
            l1 = b.Neighbors;
            l1.Add(a);
            b.Neighbors = l1;
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if(a.Neighbors.Contains(b) && b.Neighbors.Contains(a))
            {
                a.Neighbors.Remove(b);
                b.Neighbors.Remove(a);
                return true;
            }
            return false;
        }

        public Vertex<T> Search(T value)
        {
            int val = -1;
            for(int i = 0; i < VertexCount; i++)
            {
                if(Vertices[i].value.Equals(value))
                {
                    return Vertices[i];
                }
            }
            return default;
        }
    }
}
