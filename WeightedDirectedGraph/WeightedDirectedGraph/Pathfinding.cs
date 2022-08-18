using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Pathfinding<T>
    where T : IComparable<T>
    {
        // func / action practice https://sharplab.io/#v2:C4LgTgrgdgPgAgJgIwFgBQ7EAICiAPAQwFsAHAGwFN0BvdLerASymCwIG46Gv64BmLHCQIsAEQD2AZWAQAZrM5oGWHoIH5i5CgApmrAgEpVtJcobAAFowDOAOgJYAvG0VmGE6XNlOsABTB6rgwAvqqq/EwsWACCxqrKAOYUrI4AfC7xDNbJKqZuJm5uDs4AbgRkEBRBhQxCAJzaACQARA42WFDiAO5Y1GUVFMHNBtVmoXlYwdwT4QJwACx+ASzaRhMFhfXahuzTyuPK6OPomHMiAMK9YRMRQgBsgoseMvKrcRPKW83WL94WBNYsAAjCgUKBYAAm4igFGGowOe1qcyQDwWYnEAFlxGAKJ5XmtlBs3F8KCUwVgiNiKFgfl4sP9ASDyVCYXDVAj6OEECJ3jUNKRKFgKIQBdTnDCevytNokABWEaZejCzSUWzPOnOCRYnF4hSKoUirRqqS/VajQ4fLAAeitvGEbAAxsBGNCfMrRQhbP5AoqbY7ndCzfrg5b6FaAFT6uCygA8egANIIkAAGdLlaziaM+Ypp2wAFRNywSQdDuRq0bjLHSsmgDoAnj5Vk50ghk8nzVH7QQnS7wc4m2kkw1Wp1wTWoA62aXOwgYxW9KlqwQANYUADqAWAFDAjaIFGs1gISQMzaH2j3B6POgMIzLhRn/t7Ik1Jq85rvbk7yZp2bIGej2h8AqpZbNYwE1LIK7rpu27aOO9bgYU3YBn2j7Qgg76cqWNrIb2PiQauG6MFuYCYR+Zi4YGiGfiBwgANoALpoVAgLihQPRCAgdEpgxZGyNiWC6FEjA+O2TBYDGzF2AAMmCCSWLsjAANRKQShREjUUl0YwTFsT0ABKBBQFCRCrLYABywrANoCAno4zjJgA/Oi2q4r8WAgOiupkRyZj6vxO5CawIkOYpElSbYslQPJFiKSpan5PqyiUSx2kMbYACSUAlOIq4ljUwThla+o2lqVK6vlIRHEAA=
        IComparer<T> comparer;
        public Pathfinding(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }
        Graph<T> g;

        public Pathfinding(Graph<T> graph)
        {
            g = graph;
        }

        public List<T> A(Vertex<T> v1, Vertex<T> v2, Func<Vertex<T>, Vertex<T>, float> heuristic)
        {
            
            heap<Vertex<T>> priorityQueue = new heap<Vertex<T>>(Comparer<Vertex<T>>.Create((x, y) => HeursticsComparer<T>.Compare(x, y)));
            Dictionary<Vertex<T>, Vertex<T>> founder = new Dictionary<Vertex<T>, Vertex<T>>();
            List<T> toReturn = new List<T>();
            v1.finalDistance = (heuristic(v1, v2));
            priorityQueue.Insert(v1);
            v1.knownDistance = 0;

            while (priorityQueue.Count > 0)
            {
                Vertex<T> current = priorityQueue.Pop();
                if (current == v2)
                {
                    List<T> toReturnB = new List<T>();
                    Vertex<T> currentP = current;
                    while (currentP != v1)
                    {
                        toReturnB.Add(currentP.value);
                        currentP = founder[currentP];
                    }
                    toReturnB.Add(v1.value);
                    for (int i = toReturnB.Count - 1; i >= 0; i--)
                    {
                        toReturn.Add(toReturnB[i]);
                    }
                    return toReturn;
                }
                foreach (Edge<T> neighborEdges in current.Neighbors)
                {

                    Vertex<T> neighbor = neighborEdges.EndingPoint;
                    float tentDistance = current.knownDistance + heuristic(neighbor, v2);
                    if (tentDistance < neighbor.knownDistance)
                    {
                        neighbor.knownDistance = tentDistance;
                        founder[neighbor] = current;
                        if (!priorityQueue.contains(neighbor))
                        {
                            priorityQueue.Insert(neighbor);
                        }
                    }

                }
            }
            return toReturn;
        }
        
        public List<T> DijkstraSearch(Vertex<T> v1, Vertex<T> v2)
        {
            heap<Vertex<T>> priorityQueue = new heap<Vertex<T>>(Comparer<Vertex<T>>.Create((x, y) => KnownDistanceComparer<T>.Compare(x, y)));
            Dictionary<Vertex<T>, Vertex<T>> founder = new Dictionary<Vertex<T>, Vertex<T>>();
            List<T> toReturn = new List<T>();
            priorityQueue.Insert(v1);
            v1.knownDistance = 0;
            while (priorityQueue.Count > 0)
            {
                Vertex<T> current = priorityQueue.Pop();
                if (current == v2)
                {
                    List<T> toReturnB = new List<T>();
                    Vertex<T> currentP = current;
                    while (currentP != v1)
                    {
                        toReturnB.Add(currentP.value);
                        currentP = founder[currentP];
                    }
                    toReturnB.Add(v1.value);
                    for (int i = toReturnB.Count - 1; i >= 0; i--)
                    {
                        toReturn.Add(toReturnB[i]);
                    }
                    return toReturn;
                }
                foreach (Edge<T> neighborEdges in current.Neighbors)
                {

                    Vertex<T> neighbor = neighborEdges.EndingPoint;
                    float tentDistance = current.knownDistance + neighborEdges.Distance;
                    if (tentDistance < neighbor.knownDistance)
                    {
                        neighbor.knownDistance = tentDistance;
                        founder[neighbor] = current;
                        priorityQueue.Insert(neighbor);
                    }

                }
            }
            return toReturn;

        }
        



        /*
        public List<T> DepthFirst(Vertex<T> v1, Vertex<T> v2)
        {
            Stack<Vertex<T>> st = new Stack<Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> founder = new Dictionary<Vertex<T>, Vertex<T>>();
            List<Vertex<T>> seen = new List<Vertex<T>>();
            List<T> empty = new List<T>();
            st.Push(v1);
            seen.Add(v1);
            while (st.Count > 0)
            {
                Vertex<T> current = st.Pop();
                if (current == v2)
                {
                    List<T> toReturnB = new List<T>();
                    Vertex<T> currentP = current;
                    while (currentP != v1)
                    {
                        toReturnB.Add(currentP.value);
                        currentP = founder[currentP];
                    }
                    toReturnB.Add(v1.value);
                    List<T> toReturn = new List<T>();
                    for (int i = toReturnB.Count - 1; i >= 0; i--)
                    {
                        toReturn.Add(toReturnB[i]);
                    }
                    return toReturn;
                }

                foreach (Edge<T> neighborEdges in current.Neighbors)
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
        */
    }
}
