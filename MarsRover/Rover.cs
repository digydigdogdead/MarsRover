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
        public Position? Position { get; private set; }
        public Plateau? Plateau { get; set; }

        private static int RoverCount = 0;

        internal Rover()
        {
            RoverCount++;
            ID = RoverCount;
        }

        public void Move(Instruction instruction)
        {

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
