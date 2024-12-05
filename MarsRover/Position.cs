using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Facing { get; set; }

        public Position(int x = 0, int y = 0, Directions facing = Directions.NORTH)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public override string ToString()
        {
            string direction = "";

            if (Facing == Directions.NORTH) direction = "North";
            else if (Facing == Directions.SOUTH) direction = "South";
            else if (Facing == Directions.WEST) direction = "West";
            else direction = "East";

            return $"Position: {X}, {Y}, " + direction;
        }
    }
}
