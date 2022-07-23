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
            st.Push(v1);
            seen.Add(v1);
            while(st != null)
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
            List<T> empty = new List<T>();
            return empty;
        }


        //bredth-first search:
        //vertex a, vertex b(both in a graph g)
        //both connected through other edges
        //dict<Vertex, bool> parents
        //parents[a] = true if parents false if not
        //Queue<Vertex> agenda
        //agenda.Add(a)
        //while agenda isnt empty
        //v1 = agenda.dequeue()
        //if v1 == b
        // path = calcualte_path(v1)
        //List<T> path
        //while v in parents
        //path.Add(v.Value)
        //return path
        //else
        // for every neighbor of v1.neighbor
        //if neighbor is in parents
        //cont
        //else
        //parents[neighbor] = true
        //agenda.Add(neighbor)
        //return null   
        public static List<T> BreadthFirst (Vertex<T> v1, Vertex<T> v2)
        {
            Dictionary<Vertex<T>, bool> dict= new Dictionary<Vertex<T>, bool>();
            Queue<Vertex<T>> Agenda = new Queue<Vertex<T>>();
            
            List<T> toReturn = new List<T>();
            return toReturn;
        }
    }
}
