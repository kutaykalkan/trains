namespace Trains.Interfaces
{
    public interface IMatrixShortestPathCalculator
    {
        /// <summary>
        /// Gets the distance of the shortest path in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="source">Start vertice</param>
        /// <param name="destination">End vertice</param>
        /// <returns>Integer value of the length of the shortest path</returns>
        int GetShortestPathDistance(int[,] matrix, int source, int destination);
    }
}
