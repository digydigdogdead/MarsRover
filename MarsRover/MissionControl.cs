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

        public static void FileForBankRuptcy()
        {
            Rovers.Clear();
            Rover.RoverCount = 0;
            Plateaus.Clear();
        }

        public static void DeployRover(Rover rover, Plateau plateau, Position position)
        {
            if (rover.isDeployed)
            {
                Console.WriteLine("This rover has already been deployed and cannot be redeployed.");
                return;
            }

            foreach (Rover existingRover in plateau.Rovers)
            {
                if (existingRover.Position.X == position.X && existingRover.Position.Y == position.Y)
                {
                    Console.WriteLine("A rover is present at this location already.");
                    return;
                }
            }

            if (position.X > plateau.Size.Xsize - 1 || position.Y > plateau.Size.Ysize - 1)
            {
                Console.WriteLine("That position does not exist on this Plateau.");
                return;
            }

            rover.Position = position;
            plateau.AddRover(rover);
            rover.isDeployed = true;

            Console.WriteLine($"Rover {rover.ID} deployed to {plateau.Name}.");

        }


    }
}
