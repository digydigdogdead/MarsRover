using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.InputClasses
{
    public static class InputParser
    {
        public static Instruction ParseInstruction(char input) => input switch
        {
            'L' => Instruction.LEFT,
            'R' => Instruction.RIGHT,
            'M' => Instruction.MOVE,
            _ => throw new ArgumentException("Invalid instruction input"),
        };

        public static Directions ParseDirections(char input) => input switch
        {
            'N' => Directions.NORTH,
            'E' => Directions.EAST,
            'S' => Directions.SOUTH,
            'W' => Directions.WEST,
            _ => throw new ArgumentException("Invalid direction input")
        };

        public static bool TryParsePosition(string? input, out Position? result)
        {
            if (String.IsNullOrEmpty(input))
            {
                result = null;
                return false;
            }

            string[] inputArray = input.Split(' ');

            if (inputArray.Length != 3)
            {
                result = null;
                return false;
            }

            bool firstNumberValid = Int32.TryParse(inputArray[0], out int xPosition);
            bool secondNumberValid = Int32.TryParse(inputArray[1], out int yPosition);

            if (!firstNumberValid || !secondNumberValid)
            {
                result = null;
                return false;
            }

            if (inputArray[2].ToUpper() != "N" && 
                inputArray[2].ToUpper() != "E" &&
                inputArray[2].ToUpper() != "S" &&
                inputArray[2].ToUpper() != "W")
            {
                result = null;
                return false;
            }

            Directions direction = ParseDirections(Char.ToUpper(inputArray[2][0]));

            result = new Position(xPosition, yPosition, direction);
            return true;
        } 

        public static bool TryParseOption(string? input, out UserOptions? result)
        {
            /*            1.Build a new Rover
                        2.Discover a new Plateau
                        3.Deploy an existing Rover
                        4.Move a rover
                        5.Take a sample
                        6. bankruptcy
                        7. exit
            */
            
            if (String.IsNullOrEmpty(input))
            {
                result = null;
                return false;
            }

            bool isNumberValid = Int32.TryParse(input, out int userChoice);

            if (!isNumberValid)
            {
                result = null;
                return false;
            }

            if (userChoice > 7 || userChoice < 1)
            {
                result = null;
                return false;
            }

            UserOptions[] optionsArray = Enum.GetValues<UserOptions>();

            result = optionsArray[userChoice-1];
            return true;
        }

        public static bool TryGetYesOrNo(string? input, out bool result)
        {
            if (string.IsNullOrEmpty(input))
            {
                result = false;
                return false;
            }

            input = input.ToLower();

            if (input.Length != 1)
            {
                result = false;
                return false;
            }

            if (input[0] != 'y' && input[0] != 'n')
            {
                result = false;
                return false;
            }
            else if (input[0] == 'y')
            {
                result = true;
                return true;
            }
            else
            {
                result = false;
                return true;
            }
        }


    }
}
