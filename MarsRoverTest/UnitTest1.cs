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
            MissionControl.FileForBankRuptcy();
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
            Action fullyInvalidInput = () => { Creator.CreatePosition("eggplant"); };
            fullyInvalidInput.Should().Throw<ArgumentException>();

            Action extraSpaceInput = () => { Creator.CreatePosition("1 2 N "); };
            extraSpaceInput.Should().Throw<ArgumentException>();

            Action notNumbersInput = () => Creator.CreatePosition("J N E");
            notNumbersInput.Should().Throw<ArgumentException>();

            Action notDirectionInput = () => Creator.CreatePosition("1 3 J");
            notDirectionInput.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PlateauSizeCreatorTest()
        {
            PlateauSize correctInput = Creator.CreatePlateauSize("3 3");
            PlateauSize expected = new(3, 3);

            correctInput.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void InvalidPlateauSizeCreatorTest()
        {
            Action fullyInvalidInput = () => Creator.CreatePlateauSize("Nigel");
            fullyInvalidInput.Should().Throw<ArgumentException>();

            Action extraSpaceInput = () => Creator.CreatePlateauSize("4 4 ");
            extraSpaceInput.Should().Throw<ArgumentException>();

            Action noMiddleSpaceInput = () => Creator.CreatePlateauSize("44");
            noMiddleSpaceInput.Should().Throw<ArgumentException>();

            Action impossibleDimensionInput = () => Creator.CreatePlateauSize("0 4");
            impossibleDimensionInput.Should().Throw<ArgumentException>();

            Action notNumbersInput = () => Creator.CreatePlateauSize("4 J");
            notNumbersInput.Should().Throw<ArgumentException>();
        }

        [Test]
        public void AddRoverTest()
        {
            Plateau testPlateau = new Plateau(4, 4, "Test");
            Rover testRover = new Rover();

            testPlateau.AddRover(testRover);
            
            testRover.Plateau.Should().Be(testPlateau);
            testPlateau.Rovers.Count().Should().Be(1);
            testPlateau.Rovers.Should().Contain(testRover);
        }

        [Test]
        public void RemoveRoverTest()
        {
            Plateau testPlateau = new Plateau(4, 4, "Test");
            Rover testRover = new Rover();

            testPlateau.AddRover(testRover);

            testPlateau.RemoveRover(testRover);

            testPlateau.Rovers.Count.Should().Be(0);
            testRover.Plateau.Should().BeNull();
        }

        [Test]
        public void RemoveNonExistantRoverTest()
        {
            Plateau testPlateau = new Plateau(4, 4, "Test");
            Rover testRover = new Rover();

            Action removeRover = () => testPlateau.RemoveRover(testRover);
            removeRover.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void AddRoverToFullPlateauTest()
        {
            Plateau testPlateau = new Plateau(1,1, "Test");
            testPlateau.MaximumCapacity.Should().Be(1);

            Rover testRover = new Rover();
            Rover testRover2 = new Rover();

            testPlateau.AddRover(testRover);
            testPlateau.Rovers.Count.Should().Be(1);

            testPlateau.AddRover(testRover2);
            testPlateau.Rovers.Count().Should().Be(1);
        }

        [Test]
        public void AddRoverToPlateauTwiceTest()
        {
            Plateau testPlateau = new Plateau(3,3, "Test");
            Rover testRover = new Rover();

            testPlateau.AddRover(testRover);
            testPlateau.Rovers.Count.Should().Be(1);

            testPlateau.AddRover(testRover);
            testPlateau.Rovers.Count.Should().Be(1);

        }

        [Test]
        public void BuildRoverTest()
        {
            var rover1 = new Rover();
            var rover2 = new Rover();

            MissionControl.Rovers.Count.Should().Be(2);

            rover1.ID.Should().Be(1);
            rover2.ID.Should().Be(2);
        }

        [Test]
        public void RegisterPlateauTest()
        {
            var testPlateau = new Plateau(4,4, "Test");
            testPlateau.Name.Should().Be("Test");
            testPlateau.Size.Xsize.Should().Be(4);
            testPlateau.Size.Ysize.Should().Be(4);

            MissionControl.Plateaus.Count.Should().Be(1);
            MissionControl.Plateaus.Should().Contain(testPlateau);
        }


    }
}