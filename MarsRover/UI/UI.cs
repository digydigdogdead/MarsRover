using MarsRover.InputClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.UI
{
    internal static class UI
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Mission Control!");
            DiscoverPlateau();
            Console.WriteLine();
            BuildRover();

        }

        public static void DiscoverPlateau()
        {
            Console.WriteLine("We have discovered a new plateau on Mars that needs analysing. What would you like to name it?");
            bool isNameNull = true;
            string? nameInput = "";
            while (isNameNull)
            {
                nameInput = Console.ReadLine();
                if (String.IsNullOrEmpty(nameInput))
                {
                    Console.WriteLine("This plateau needs a name!");
                }
                else isNameNull = false;
            }
            Console.WriteLine("I've left my space ruler at home. How big do you reckon it is?");
            bool sizeCreated = false;
            while (!sizeCreated)
            {
                Console.WriteLine("Input a size in the format \"x y\"");
                string? sizeInput = Console.ReadLine();
                try
                {
                    PlateauSize newSize = Creator.CreatePlateauSize(sizeInput);
                    Plateau newPlateau = new Plateau(newSize, nameInput);
                    Console.WriteLine($"{newPlateau.Name} has been added to the database.");
                    sizeCreated = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void BuildRover()
        {
            Console.WriteLine("Building new rover...");
            Rover newRover = new Rover();
            Console.WriteLine($"New Rover built! This Rover's ID is {newRover.ID}");
            Console.WriteLine("Would you like to deploy this Rover immediately? Input Y or N.");
            bool yOrNValid = false;
            bool userChoice = false;
            while (!yOrNValid)
            {
                string? yOrNInput = Console.ReadLine();
                yOrNValid = InputParser.TryGetYesOrNo(yOrNInput, out userChoice);
                if (!yOrNValid) Console.WriteLine("Input was invalid, please try again.");
            }

            if (userChoice)
            {
                UserDeployRover(newRover);

                
            }
        }

        public static void GetAllPlateaus()
        {
            for (int i = 0; i < MissionControl.Rovers.Count; i++)
            {
                Console.WriteLine($"{i+1}. {MissionControl.Plateaus[i].ToString()}");
            }
        }

        public static void UserDeployRover(Rover rover)
        {
            Console.WriteLine($"Which Plateau would you like to deploy Rover {rover.ID} to?");
            GetAllPlateaus();
            Plateau? plateauChoice = Input.ChoosePlateau();
            if (plateauChoice is null)
            {
                Console.WriteLine("Deployment cancelled.");
                return;
            }

            GetAllRoverPositionsAtPlateau(plateauChoice);
            Console.WriteLine("What position would you like to deploy the rover to?");
            Console.WriteLine("Please enter a position in the format \"X Y D\", where X and Y are co-ordinates and D is a cardinal direction NESW.");
            bool isPositionValid = false;
            Position? startingPosition = null;
            while (!isPositionValid)
            {
                string? positionInput = Console.ReadLine();
                isPositionValid = InputParser.TryParsePosition(positionInput, out startingPosition);
                if (!isPositionValid) 
                {
                    Console.WriteLine("Position was invalid, please try again:");
                }
            }

            if (plateauChoice.CheckPositionIsFree(startingPosition))
            {
                Console.WriteLine($"Deploying Rover {rover.ID} to {plateauChoice.Name}...");
                MissionControl.DeployRover(rover, plateauChoice, startingPosition);
            }
            else
            {
                Console.WriteLine("That position is occupied or non-existant in this Plateau. Cancelling deployment...");
            }
        }

        public static void GetAllRoverPositionsAtPlateau(Plateau plateau)
        {
            if (plateau.Rovers.Count == 0)
            {
                Console.WriteLine("There are no rovers currently at this Plateau.");
            }
            else
            {
                Console.WriteLine("Rovers currently on this Plateau include:");
                foreach (Rover rover in plateau.Rovers)
                {
                    Console.WriteLine($"Rover {rover.ID}, {rover.Position.ToString()}");
                }
            }
        }
    }
}
