using System;
using System.Collections.Generic;
using Trains.Interfaces;
using Trains.Utilities;

namespace Trains.Implementations
{
    public class DijkstrasShortestPathMatrixImpl : IMatrixShortestPathCalculator
    {
        public int GetShortestPathDistance(int[,] matrix, int source, int destination)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            return Dijkstra(matrix, source, destination, matrix.GetLength(0));
        }

        private int Dijkstra(int[,] matrix, int src, int dest, int numVertices) {
            int[] dist = new int[numVertices];
            for (int i = 0; i < numVertices; i++) {
                dist[i] = int.MaxValue;
            }

            bool[] closed = new bool[numVertices];
            MinHeap<KeyValuePair<int, int>> closestNeighbour = new MinHeap<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Value.CompareTo(y.Value)));
            
            dist[src] = 0;
            closestNeighbour.Add(new KeyValuePair<int, int>(src, dist[src]));
            bool flag = false;
            while (closestNeighbour.Count > 0)
            {
                KeyValuePair<int, int> item = closestNeighbour.ExtractDominating();

                int u = item.Key;
                
                //Early exit condition. Flag is for handling start == end condition.
                if (u == dest && flag)
                {
                    break;
                }
                
                closed[u] = true; // Mark the picked vertex as processed

                // Update dist value of the adjacent vertices of the
                // picked vertex.
                for (int v = 0; v < numVertices; v++)
                {
                    // Update dist[v] only if is not closed, there is an
                    // edge from u to v, and total weight of path from src to
                    // v through u is smaller than current value of dist[v]
                    if (!closed[v] && matrix[u, v] != int.MaxValue &&
                        dist[u] != int.MaxValue && dist[u] + matrix[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + matrix[u, v];
                        closestNeighbour.Add(new KeyValuePair<int, int>(v, dist[v]));
                    }

                }
                // Update the last vertice when start == end
                if (matrix[u, dest] != int.MaxValue && dist[u] != int.MaxValue)
                {
                    if(dist[dest] == 0)
                        dist[dest] = dist[u] + matrix[u, dest];
                    else
                    {
                        if (dist[u] + matrix[u, dest] < dist[dest])
                        {
                            dist[dest] = dist[u] + matrix[u, dest];
                        }
                    }
                }
                flag = true;
            }
            return dist[dest];
        }
    }

    
}
