using System.Collections.Generic;
using System.Linq;
using Trains.Interfaces;

namespace Trains.Implementations
{
    public class MatrixPathUpToMaxCounter : IMatrixPathUpToMaxCounter
    {
        public int GetNumberOfPaths(int[,] matrix, int source, int destination, int max)
        {
            Dictionary<List<int>, int> memo = new Dictionary<List<int>, int>(new ListComparer<int>());
            return GetNumberOfPaths(source, destination, matrix, ref memo, matrix.GetLength(0), max);
        }

        private int GetNumberOfPaths(int source, int destination, int[,] matrix, ref Dictionary<List<int>, int> memo, int numVertices, int max)
        {
            for (int dest = 0; dest < numVertices; dest++)//initial setup for base routes.
            {
                if (matrix[source, dest] != int.MaxValue && matrix[source, dest] != 0)
                if (!memo.ContainsKey(new List<int>() { source, dest })) {
                    memo.Add(new List<int>() { source, dest }, matrix[source, dest]);

                }
            }
            bool flag = true;
            int count = memo.Count;
            while (flag)//iterate until all cycles are used up to the max.
            {
                int countCheck = count;
                for (int start = 1; start < numVertices; start++)
                {
                    for (int i = 0; i < numVertices; i++)
                    {
                        if (matrix[start, i] != int.MaxValue && matrix[start, i] != 0)
                        {
                            if (memo.Count(x => x.Key.Last() == start) > 0)
                            {
                                foreach (var item in memo.Where(x => x.Key.Last() == start).ToDictionary(x => x.Key, x => x.Value))
                                {
                                    int d = item.Value;
                                    List<int> key = item.Key.ToList();
                                    
                                    if (d + matrix[start, i] < max)
                                    {
                                        key.Add(i);
                                        if (memo.ContainsKey(key))
                                            continue;
                                        memo.Add(key, d + matrix[start, i]);
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (count == countCheck)
                    flag = false;
            }
            
            return memo.Count(x => x.Key.First() == source && x.Key.Last() == destination);
        }

        private class ListComparer<T> : IEqualityComparer<List<T>>
        {
            public bool Equals(List<T> x, List<T> y) {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(List<T> obj) {
                int hashcode = 0;
                foreach (T t in obj) {
                    hashcode ^= t.GetHashCode();
                }
                return hashcode;
            }
        }
    }
}
