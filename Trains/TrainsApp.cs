using System;
using System.Collections.Generic;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains
{
    public class TrainsApp : ITrainsApp
    {
        private readonly IInputReader _reader;
        private readonly IInputConverter _inputConverter;

        public TrainsApp(IInputReader reader, IInputConverter inputConverter)
        {
            _reader = reader;
            _inputConverter = inputConverter;
        }
        
        public void Run()
        {
            try
            {
                List<string> input = _reader.GetInputByLine();
                int[,] routes = _inputConverter.ConvertToMatrix(input[0]);
                ITrainSchedules ts = new TrainSchedules(routes, new DijkstrasShortestPathMatrixImpl(),
                    new MatrixDistanceCalculator(), new MatrixRouteCounter(routes), new MatrixPathUpToMaxCounter());
                for (int i = 1; i < input.Count; i++)
                {
                    string[] lineItems = input[i].Split(' ');
                    Enum.Query query;
                    bool success = System.Enum.TryParse(lineItems[0], out query);
                    if (!success)
                    {
                        Console.WriteLine("Problem reading query type.");
                        continue;
                    }

                    switch (query)
                    {
                        case Enum.Query.Distance:
                            int result = ts.GetDistance(new List<char>(lineItems[1].ToCharArray()));
                            Console.WriteLine(result == -1 ? "NO SUCH ROUTE" : result.ToString());
                            break;
                        case Enum.Query.NumberOfTripsMax:
                            Console.WriteLine(ts.GetRoutesCountUpToMax(lineItems[1][0], lineItems[1][1], int.Parse(lineItems[2])));
                            break;
                        case Enum.Query.NumberOfTripsExact:
                            Console.WriteLine(ts.GetRoutesCountExact(lineItems[1][0], lineItems[1][1], int.Parse(lineItems[2])));
                            break;
                        case Enum.Query.LengthOfShortestRoute:
                            Console.WriteLine(ts.GetShortestPathDistance(lineItems[1][0], lineItems[1][1]));
                            break;
                        case Enum.Query.NumberOfRoutesUpToMaxDistance:
                            Console.WriteLine(ts.GetNumberOfPathsWithMaxLength(lineItems[1][0], lineItems[1][1], int.Parse(lineItems[2])));
                            break;
                        default:
                            Console.WriteLine("Invalid query type.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public interface IInputReader
    {
        List<string> GetInputByLine();
    }
}
