using MarsRover;
using FluentAssertions;
using MarsRover.InputClasses;

namespace MarsRoverTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseDirectionTest()
        {
            var resultN = InputParser.ParseDirections('N');
            var resultE = InputParser.ParseDirections('E');
            var resultS = InputParser.ParseDirections('S');
            var resultW = InputParser.ParseDirections('W');

            resultN.Should().Be(Directions.NORTH);
            resultE.Should().Be(Directions.EAST);
            resultS.Should().Be(Directions.SOUTH);
            resultW.Should().Be(Directions.WEST);
        }

        [Test]
        public void ParseInvalidDirectionsTest()
        {
            Action invalidInput = () => { InputParser.ParseDirections('L'); };

            invalidInput.Should().Throw<ArgumentException>();
        }
    }
}