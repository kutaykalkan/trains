using System;
using System.Collections.Generic;
using Trains.Interfaces;

namespace Trains.Implementations
{
    public class MatrixRouteCounter : IMatrixRouteCounter
    {
        private readonly int[,] _matrix;
        private readonly int _numVertices;
        public MatrixRouteCounter(int[,] matrix)
        {
            _matrix = matrix;
            _numVertices = matrix.GetLength(0);
        }
        public int GetRoutesCountUpToMax(int source, int destination, int maxHop)
        {
            ValidateInput(source, destination);
            Dictionary<string, int> memo = new Dictionary<string, int>();
            int count = 0;
            for (int k = maxHop; k > 0; k--) {
                count += GetRoutes(source, destination, k, ref memo);
            }
            return count;
        }

        public int GetRoutesCountExact(int source, int destination, int numberOfHops)
        {
            ValidateInput(source, destination);
            var dictionary = new Dictionary<string, int>();
            return GetRoutes(source, destination, numberOfHops, ref dictionary);
        }

        private int GetRoutes(int source, int destination, int numEdges, ref Dictionary<string, int> memo) {
            if (numEdges == 0 && source == destination) {
                return 1;
            }
            if (numEdges == 0)
                return 0;

            string key = source + destination.ToString() + numEdges;
            if (memo.ContainsKey(key))
                return memo[key];
            int count = 0;
            for (int i = 0; i < _numVertices; i++) {
                if (_matrix[source, i] != int.MaxValue && _matrix[source, i] != 0) {
                    count = count + GetRoutes(i, destination, numEdges - 1,  ref memo);
                    memo[key] = count;

                }
            }
            return count;
        }

        private void ValidateInput(int source, int destination)
        {
            if(source > _numVertices - 1)
                throw new IndexOutOfRangeException(nameof(source));
            if(destination > _numVertices - 1)
                throw new IndexOutOfRangeException(nameof(destination));
        }
    }
}
