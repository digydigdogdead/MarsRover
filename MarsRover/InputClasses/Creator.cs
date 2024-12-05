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

        public static PlateauSize CreatePlateauSize(string input)
        {
            string[] inputArray = input.Split(' ');
            if (inputArray.Length != 2) throw new ArgumentException("Plateau Size input was incorrect length");
            
            bool isXValid = Int32.TryParse(inputArray[0], out int x);
            bool isYValid = Int32.TryParse(inputArray[1], out int y);

            if (!isXValid || !isYValid) throw new ArgumentException("Plateau Size input was invalid.");

            if (x < 1 || y < 1) throw new ArgumentException("Plateau Size must be greater than 0");

            return new PlateauSize(x, y);
        }
    }
}
