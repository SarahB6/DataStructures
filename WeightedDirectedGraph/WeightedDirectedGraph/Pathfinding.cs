using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Pathfinding<T>
    {
        Graph<T> g;

         public Pathfinding(Graph<T> graph)
            {
                g = graph;
            }
        public List<T> DepthFirst (Vertex<T> v1, Vertex<T> v2)
        {
            Stack<Vertex<T>> st = new Stack<Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> founder = new Dictionary<Vertex<T>, Vertex<T>>();
            List<Vertex<T>> seen = new List<Vertex<T>>();
            List<T> empty = new List<T>();
            st.Push(v1);
            seen.Add(v1);
            while(st.Count > 0)
            {
                Vertex<T> current = st.Pop();
                if (current == v2)
                {
                    List<T> toReturnB = new List<T>();
                    Vertex<T> currentP = current;
                    while(currentP != v1)
                    {
                        toReturnB.Add(currentP.value);
                        currentP = founder[currentP];
                    }
                    toReturnB.Add(v1.value);
                    List<T> toReturn = new List<T>();
                    for(int i = toReturnB.Count-1; i>=0; i--)
                    {
                        toReturn.Add(toReturnB[i]);
                    }
                    return toReturn;
                }

                foreach(Edge<T> neighborEdges in current.Neighbors)
                {
                    Vertex<T> neighbor = neighborEdges.EndingPoint;
                    if (!seen.Contains(neighbor))
                    {
                        st.Push(neighbor);
                        seen.Add(neighbor);
                        founder[neighbor] = current;
                    }
                }
            }
            
            return empty;
        }


       
        public static List<T> BreadthFirst (Vertex<T> v1, Vertex<T> v2)
        {
            Dictionary<Vertex<T>, bool> dict= new Dictionary<Vertex<T>, bool>();
            Queue<Vertex<T>> Agenda = new Queue<Vertex<T>>();
            
            List<T> toReturn = new List<T>();
            return toReturn;
        }
    }
}
