using System;
using NUnit.Framework;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains.Tests
{
    [TestFixture]
    public class DijkstrasShortestPathMatrixImplTest
    {
        private readonly IInputConverter _converter;

        public DijkstrasShortestPathMatrixImplTest()
        {
            _converter = new InputConverter();
        }

        [Test]
        public void GetShortestPath_WhenMatrixIsNull_ThrowException()
        {
            DijkstrasShortestPathMatrixImpl obj = new DijkstrasShortestPathMatrixImpl();
            Assert.Throws<ArgumentNullException>(() => obj.GetShortestPathDistance(null, 0, 0));
        }

        [TestCase("Graph: AB1, BC3, AC2", 0, 2, ExpectedResult = 2)] //Without cycle
        [TestCase("Graph: AB5, BA1, AC2, CD2, DA3", 0, 0, ExpectedResult = 6)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 0, 2, ExpectedResult = 9)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 2, 2, ExpectedResult = 9)]
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 0, 1, ExpectedResult = 5)]
        public int GetShortestPathWithCycleTest(string input, int source, int destination) {
            DijkstrasShortestPathMatrixImpl obj = new DijkstrasShortestPathMatrixImpl();
            int actual = obj.GetShortestPathDistance(_converter.ConvertToMatrix(input), source, destination);
            return actual;
        }


    }
}