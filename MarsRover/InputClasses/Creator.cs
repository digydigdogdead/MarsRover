using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.InputClasses
{
    public static class Creator
    {
        public static Position CreatePosition(string input)
        {
            if (input.Length != 5) throw new ArgumentException("Position input was invalid.");

            string[] inputArray = input.Split(' ');

            bool isXValid = Int32.TryParse(inputArray[0], out int x);
            bool isYValid = Int32.TryParse(inputArray[1], out int y);

            if (!isXValid || !isYValid) throw new ArgumentException("Position input was invalid.");

            Directions facing = InputParser.ParseDirections(inputArray[2][0]);

            return new Position(x, y, facing);
        }
    }
}
