using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains.Tests
{
    [TestFixture]
    public class MatrixDistanceCalculatorTest
    {
        private readonly IMatrixDistanceCalculator _matrixDistanceCalculator;
        private readonly IInputConverter _inputConverter;
        public MatrixDistanceCalculatorTest()
        {
            _matrixDistanceCalculator = new MatrixDistanceCalculator();
            _inputConverter = new InputConverter();
        }
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", new []{ 0, 4, 1, 2, 3 }, ExpectedResult = "22")]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", new[] { 0, 4, 3 }, ExpectedResult = "NO SUCH ROUTE")]
        public string TestGetDistance(string matrixRepresentation, int[] route)
        {
            int result = _matrixDistanceCalculator.GetDistance(_inputConverter.ConvertToMatrix(matrixRepresentation), route.ToList());
            string returnVal = result.ToString();
            if (result == -1)
                returnVal = "NO SUCH ROUTE";
            return returnVal;
        }
    }
}