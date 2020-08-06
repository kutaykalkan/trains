using System.Collections.Generic;

namespace Trains.Interfaces
{
    public interface ITrainSchedules
    {
        /// <summary>
        /// Gets the distance between two destinations in terms of stops.
        /// </summary>
        /// <param name="route">List of Routes. Ex:A, B, C</param>
        /// <returns>Integer value of the number of stops between two destinations</returns>
        int GetDistance(List<char> route);

        /// <summary>
        /// Gets the number of trips between two destinations with a max number of stops provided.
        /// </summary>
        /// <param name="source">Start city</param>
        /// <param name="destination">End city</param>
        /// <param name="maxNumberOfStops">Max number of stops to the end destination</param>
        /// <returns>Integer value of the number of routes</returns>
        int GetRoutesCountUpToMax(char source, char destination, int maxNumberOfStops);

        /// <summary>
        /// Gets the number of trips between two destinations with an exact number of stops provided.
        /// </summary>
        /// <param name="source">Start city</param>
        /// <param name="destination">End city</param>
        /// <param name="numberOfStops">Exact number of stops to the end destination</param>
        /// <returns>Integer value of the number of routes</returns>
        int GetRoutesCountExact(char source, char destination, int numberOfStops);

        /// <summary>
        /// Gets the length of the shortest route.
        /// </summary>
        /// <param name="source">Start city</param>
        /// <param name="destination">End city</param>
        /// <returns>Integer value of the length of the shortest path from source to destination</returns>
        int GetShortestPathDistance(char source, char destination);

        /// <summary>
        /// Gets the number of paths within a certain length.
        /// </summary>
        /// <param name="source">Start city</param>
        /// <param name="destination">End city</param>
        /// <param name="max">Maximum length from source to destination</param>
        /// <returns>Integer value of the number of paths that meets the max length criteria</returns>
        int GetNumberOfPathsWithMaxLength(char source, char destination, int max);
    }
}