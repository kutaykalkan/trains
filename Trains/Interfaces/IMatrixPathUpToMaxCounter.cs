namespace Trains.Interfaces
{
    public interface IMatrixPathUpToMaxCounter
    {
        /// <summary>
        /// Gets number of paths from source to destination within given number of range.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="source">Start vertice</param>
        /// <param name="destination">End vertice</param>
        /// <param name="max">Maximum number of hops</param>
        /// <returns>Integer value of the number of paths</returns>
        int GetNumberOfPaths(int[,] matrix, int source, int destination, int max);
    }
}
