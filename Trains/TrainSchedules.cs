using System.Collections.Generic;
using Trains.Interfaces;

namespace Trains
{
    public class TrainSchedules : ITrainSchedules
    {
        private const int Offset = 'A';
        private readonly int[,] _routes;
        private readonly IMatrixShortestPathCalculator _matrixShortestPathCalculator;
        private readonly IMatrixDistanceCalculator _matrixDistanceCalculator;
        private readonly IMatrixRouteCounter _matrixRouteCounter;
        private readonly IMatrixPathUpToMaxCounter _matrixPathUpToMaxCounter;
        public TrainSchedules(int[,] routes, IMatrixShortestPathCalculator matrixShortestPathCalculator, IMatrixDistanceCalculator matrixDistanceCalculator, IMatrixRouteCounter matrixRouteCounter, IMatrixPathUpToMaxCounter matrixPathUpToMaxCounter)
        {
            _routes = routes;
            _matrixShortestPathCalculator = matrixShortestPathCalculator;
            _matrixDistanceCalculator = matrixDistanceCalculator;
            _matrixRouteCounter = matrixRouteCounter;
            _matrixPathUpToMaxCounter = matrixPathUpToMaxCounter;
        }

        public int GetDistance(List<char> route)
        {
            List<int> routeList = new List<int>();
            route.ForEach(x => routeList.Add(char.ToUpper(x) - Offset));
            return _matrixDistanceCalculator.GetDistance(_routes, routeList);
        }

        public int GetRoutesCountUpToMax(char source, char destination, int maxNumberOfStops)
        {
            return _matrixRouteCounter.GetRoutesCountUpToMax(Convert(source), Convert(destination), maxNumberOfStops);
        }

        public int GetRoutesCountExact(char source, char destination, int numberOfStops)
        {
            return _matrixRouteCounter.GetRoutesCountExact(Convert(source), Convert(destination), numberOfStops);
        }

        public int GetShortestPathDistance(char source, char destination) {
            return _matrixShortestPathCalculator.GetShortestPathDistance(_routes, Convert(source), Convert(destination));
        }

        public int GetNumberOfPathsWithMaxLength(char source, char destination, int max)
        {
            return _matrixPathUpToMaxCounter.GetNumberOfPaths(_routes, Convert(source), Convert(destination), max);
        }

        private int Convert(char c)
        {
            return char.ToUpper(c) - Offset;
        }
    }
}
