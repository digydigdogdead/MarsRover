using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public static class MissionControl
    {
        public static List<Rover> Rovers = new List<Rover>();
        public static List<Plateau> Plateaus = new List<Plateau>();

        public static Rover BuildRover()
        {
            Rover rover = new Rover();
            Rovers.Add(rover);
            return rover;
        }
    }
}
