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
            _ => throw new ArgumentException("Invalid direction input"),
        };
    }
}
