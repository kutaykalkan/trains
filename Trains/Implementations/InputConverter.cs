using System;
using System.Collections.Generic;
using Trains.Interfaces;

namespace Trains.Implementations
{
    public class InputConverter : IInputConverter
    {
        public int[,] ConvertToMatrix(string input)
        {
            List<string> routes = new List<string>();
            char largestOrderVertice = 'A';
            int start = -1;
            for (int i = 7; i < input.Length; i++) {
                char c = input[i];
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == ',' || c == ' '))
                {
                    throw new Exception("Invalid Input String.");
                }
                
                if (c == ',')
                {
                    if (start != -1)
                    {
                        routes.Add(input.Substring(start, i - start));
                        start = -1;
                    }
                }
                if (i == input.Length - 1)
                {
                    if (start != -1)
                    {
                        routes.Add(input.Substring(start, i - start + 1));
                    }
                }
                if(c == ',' || c == ' ')
                    continue;

                if (start == -1)
                    start = i;
                if (c >= 'a' && c <= 'z') {
                    c = Char.ToUpper(c);
                }
                if (c > largestOrderVertice)
                    largestOrderVertice = c;
            }
            int length = largestOrderVertice - 'A' + 1;

            return GetRouteMatrix(length, routes);
        }

        private int[,] GetRouteMatrix(int length, List<string> routes) {
            int[,] routeMatrix = new int[length, length];
            int offset = 'A';
            foreach (var route in routes) {
                int begin = Char.ToUpper(route[0]) - offset;
                int end = Char.ToUpper(route[1]) - offset;
                int weight = Int32.Parse(route.Substring(2));
                routeMatrix[begin, end] = weight;
            }

            for (int i = 0; i < length; i++) {
                for (int k = 0; k < length; k++) {
                    if (i == k)
                        continue;
                    if (routeMatrix[i, k] == 0)
                        routeMatrix[i, k] = int.MaxValue;
                }
            }

            return routeMatrix;
        }
    }
}
