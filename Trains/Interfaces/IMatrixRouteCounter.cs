namespace Trains.Interfaces
{
    public interface IMatrixRouteCounter
    {
        /// <summary>
        /// Gets the count of routes given the max number of hops.
        /// </summary>
        /// <param name="source">Start vertice</param>
        /// <param name="destination">End vertice</param>
        /// <param name="maxHop">Max number of hops from start to end vertice</param>
        /// <returns>Integer value of the number of routes</returns>
        int GetRoutesCountUpToMax(int source, int destination, int maxHop);

        /// <summary>
        /// Gets the count of routes given the exact number of hops.
        /// </summary>
        /// <param name="source">Start vertice</param>
        /// <param name="destination">End vertice</param>
        /// <param name="numberOfHops">Exact number of hops from start to end vertice</param>
        /// <returns>Integer value of the number of routes</returns>
        int GetRoutesCountExact(int source, int destination, int numberOfHops);
    }
}
