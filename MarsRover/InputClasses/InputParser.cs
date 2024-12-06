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
