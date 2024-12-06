using MarsRover.InputClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public int ID { get; }
        public Position? Position { get; set; }
        public Plateau? Plateau { get; set; }
        public bool isDeployed { get; set; } = false;

        public static int RoverCount = 0;

        public Rover()
        {
            RoverCount++;
            ID = RoverCount;
            MissionControl.Rovers.Add(this);
        }

        public void Move(Instruction instruction)
        {
            if (instruction == Instruction.RIGHT)
            {
                switch (Position.Facing)
                {
                    case Directions.NORTH:
                        Position.Facing = Directions.EAST;
                        break;
                    case Directions.EAST:
                        Position.Facing = Directions.SOUTH;
                        break;
                    case Directions.SOUTH:
                        Position.Facing = Directions.WEST;
                        break;
                    case Directions.WEST:
                        Position.Facing = Directions.NORTH;
                        break;
                }
            }

            if (instruction == Instruction.LEFT)
            {
                switch (Position.Facing)
                {
                    case Directions.NORTH:
                        Position.Facing = Directions.WEST;
                        break;
                    case Directions.EAST:
                        Position.Facing = Directions.NORTH;
                        break;
                    case Directions.SOUTH:
                        Position.Facing = Directions.EAST;
                        break;
                    case Directions.WEST:
                        Position.Facing = Directions.SOUTH;
                        break;
                }
            }

            if (instruction == Instruction.MOVE)
            {
                MoveForward();
            }
        }

        private void MoveForward()
        {
            if (IsNotAtEdge() && SpaceIsUnoccupied(out Position nextPosition))
            {
                Position = nextPosition;
            }
            else Console.WriteLine("Movement is invalid.");
        }

        private bool IsNotAtEdge()
        {
            if (Position.Facing == Directions.NORTH)
            {
                if (Position.Y == Plateau.Size.Ysize - 1) return false;
                else return true;
            }
            else if (Position.Facing == Directions.EAST)
            {
                if (Position.X == Plateau.Size.Xsize - 1) return false;
                else return true;
            }
            else if (Position.Facing == Directions.SOUTH)
            {
                if (Position.Y == 0) return false;
                else return true;
            }
            else
            {
                if (Position.X == 0) return false;
                else return true;
            }
        }

        private bool SpaceIsUnoccupied(out Position nextPosition)
        {
            Position newPosition = Position.Facing switch
            {
                Directions.NORTH => new Position(Position.X, Position.Y + 1, Directions.NORTH),
                Directions.EAST => new Position(Position.X + 1, Position.Y, Directions.EAST),
                Directions.SOUTH => new Position(Position.X, Position.Y - 1, Directions.SOUTH),
                Directions.WEST => new Position(Position.X - 1, Position.Y, Directions.WEST),
                _ => throw new ArgumentException("Not a valid direction.")
            };

            nextPosition = newPosition;

            foreach (Rover rover in Plateau.Rovers)
            {
                if (rover.Position.X == newPosition.X && rover.Position.Y == newPosition.Y)
                {
                    return false;
                }
            }

            return true;
        }

        public void ReceiveInstructions(string instructions)
        {
            foreach(char c in instructions)
            {
                Move(InputParser.ParseInstruction(c));
            }
        }

        public void CollectSample()
        {
            if (!isDeployed)
            {
                Console.WriteLine("This Rover is not at a plateau to get samples from.");
                return;
            }

            Sample sample = new();

            Plateau.Samples.Add(sample);
        }
        public override string ToString()
        {
            string IDstring = $"Rover {ID}";

            if (Position is null || Plateau is null)
            {
                return IDstring;
            }
            else
            {
                return $"{IDstring}, currently at {Position.ToString()} in {Plateau.ToString()}";
            }
        }
    }
}
