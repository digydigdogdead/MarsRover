using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.InputClasses
{
    internal static class InputParser
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
    }
}
