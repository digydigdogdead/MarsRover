using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Rover
    {
        public int ID { get; }
        public Position Position { get; private set; }
        public Plateau? Plateau { get; set; }

        private static int RoverCount = 0;
    }
}
