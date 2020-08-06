using System.Collections.Generic;
using Trains.Interfaces;

namespace Trains.Implementations
{
    public class MatrixDistanceCalculator : IMatrixDistanceCalculator
    {
        public int GetDistance(int[,] matrix, List<int> vertice)
        {
            int distance = 0;
            int count = 0;
            while (count < vertice.Count - 1) {
                int beginRoute = vertice[count];
                int endRoute = vertice[count + 1];
                if (matrix[beginRoute, endRoute] == int.MaxValue) {
                    distance = -1;
                    break;
                }
                distance = distance + matrix[beginRoute, endRoute];
                count++;
            }

            return distance;
        }
    }
}
