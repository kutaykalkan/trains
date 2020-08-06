using System;
using NUnit.Framework;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains.Tests
{
    [TestFixture]
    public class MatrixRouteCounterTest
    {
        private readonly MatrixRouteCounter _matrixRouteCounter;
        public MatrixRouteCounterTest()
        {
            var matrix = new InputConverter().ConvertToMatrix("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            _matrixRouteCounter = new MatrixRouteCounter(matrix);
        }

        [Test]
        public void TestGetRoutesCountUpToMaxWhenInvalidInputThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _matrixRouteCounter.GetRoutesCountUpToMax(5, 5, 5));
        }

        [TestCase(0, 2, 4, ExpectedResult = 6)]
        [TestCase(2, 2, 3, ExpectedResult = 2)]
        public int TestGetRoutesCountUpToMax(int start, int end, int max)
        {
            return _matrixRouteCounter.GetRoutesCountUpToMax(start, end, max);
        }

        [TestCase(0, 4, 4, ExpectedResult = 3)]
        [TestCase(0, 2, 4, ExpectedResult = 3)]
        [TestCase(0, 2, 1, ExpectedResult = 0)]
        public int TestGetRoutesCountExact(int start, int end, int max) {
            return _matrixRouteCounter.GetRoutesCountExact(start, end, max);
        }

        [Test]
        public void TestGetRoutesCountExactWhenInvalidInputThenThrowException() {
            Assert.Throws<IndexOutOfRangeException>(() => _matrixRouteCounter.GetRoutesCountExact(4, 5, 5));
        }
    }
}