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

        [Test]
        public void ParseInstructionsTest() 
        {
            var resultL = InputParser.ParseInstruction('L');
            var resultR = InputParser.ParseInstruction('R');
            var resultM = InputParser.ParseInstruction('M');

            resultL.Should().Be(Instruction.LEFT);
            resultR.Should().Be(Instruction.RIGHT);
            resultM.Should().Be(Instruction.MOVE);
        }

        [Test]
        public void ParseInvalidInstructionTest()
        {
            Action invalidInput = () => { InputParser.ParseInstruction('d'); };
            invalidInput.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PositionCreatorTest()
        {
            var position1 = Creator.CreatePosition("1 2 N");
            Position expected1 = new Position(1, 2, Directions.NORTH);

            position1.Should().BeEquivalentTo(expected1);
        }

        [Test]
        public void InvalidPositionCreatorTest()
        {
            Action invalidInput = () => { Creator.CreatePosition("eggplant"); };
            invalidInput.Should().Throw<ArgumentException>();
        }
    }
}