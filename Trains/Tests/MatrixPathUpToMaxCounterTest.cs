using NUnit.Framework;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains.Tests
{
    [TestFixture]
    public class MatrixPathUpToMaxCounterTest
    {
        private readonly IInputConverter _inputConverter;
        private readonly IMatrixPathUpToMaxCounter _counter;
        public MatrixPathUpToMaxCounterTest()
        {
            _inputConverter = new InputConverter();
            _counter = new MatrixPathUpToMaxCounter();
        }
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 2, 2, 30, ExpectedResult = 7)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7, EF2, FE2", 3, 1, 14, ExpectedResult = 3)]
        public int TestGetNumberOfPaths(string matrixRepresentation, int source, int destination, int maxLength)
        {
            return _counter.GetNumberOfPaths(_inputConverter.ConvertToMatrix(matrixRepresentation), source, destination, maxLength);
        }
    }
}