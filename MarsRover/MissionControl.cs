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

        public static void FileForBankRuptcy()
        {
            Rovers.Clear();
            Rover.RoverCount = 0;
            Plateaus.Clear();
        }

        public static Plateau RegisterPlateau(int plateauSizeX, int plateauSizeY, string name)
        {
           PlateauSize size = new PlateauSize(plateauSizeX, plateauSizeY);

           return RegisterPlateau(size, name);
        }

        public static Plateau RegisterPlateau(PlateauSize size, string name)
        {
            Plateau result = new Plateau(size, name);
            Plateaus.Add(result);
            return result;
        }


    }
}
