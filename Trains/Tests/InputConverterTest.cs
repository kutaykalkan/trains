using System;
using NUnit.Framework;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains.Tests
{
    [TestFixture]
    public class InputConverterTest
    {
        private readonly IInputConverter _inputConverter;
        public InputConverterTest()
        {
            _inputConverter = new InputConverter();
        }

        [Test]
        public void TestWhenInputStringIsValidThenReturnMatrix()
        {
            string input = "Graph: aB1, BC2, CA3";
            int[,] expected = new int[3, 3];
            expected[0, 0] = 0;
            expected[0, 1] = 1;
            expected[0, 2] = int.MaxValue;
            expected[1, 0] = int.MaxValue;
            expected[1, 1] = 0;
            expected[1, 2] = 2;
            expected[2, 0] = 3;
            expected[2, 1] = int.MaxValue;
            expected[2, 2] = 0;
            Assert.That(expected, Is.EquivalentTo(_inputConverter.ConvertToMatrix(input)));
        }

        [Test]
        public void TestWhenInputStringHasInvalidCharsThenThrowException() {
            string input = "Graph: 'B1, BC2, CA3";
            Assert.Throws<Exception>(() => _inputConverter.ConvertToMatrix(input));
        }
    }
}