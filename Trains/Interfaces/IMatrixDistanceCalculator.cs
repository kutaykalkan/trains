using System.Collections.Generic;

namespace Trains.Interfaces
{
    public interface IMatrixDistanceCalculator
    {
        /// <summary>
        /// Gets the distance from the beginning to the end vertice. Routes should be connected.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="vertice">List of vertices</param>
        /// <returns>Length of the distance from the start vertice to the end vertice</returns>
        int GetDistance(int[,] matrix, List<int> vertice);
    }
}
