using MarsRover.Enums;
using MarsRover.InputClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.UI
{
    public static class UI
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Mission Control!");
            DiscoverPlateau();
            Console.WriteLine();
            BuildRover();
            while (true)
            {
                Console.WriteLine();
                UserOptions userChoice = GetUserOptions();
                switch (userChoice)
                {
                    case UserOptions.BUILD:
                        BuildRover();
                        break;

                    case UserOptions.DISCOVER_PLATEAU:
                        DiscoverPlateau();
                        break;

                    case UserOptions.DEPLOY_ROVER:
                        Rover rover = Input.ChooseRoverAtSource(MissionControl.Rovers);
                        if (rover is null)
                        {
                            continue;
                        }
                        UserDeployRover(rover);
                        break;

                    case UserOptions.MOVE_ROVER:
                        UserMoveRover();
                        break;


                    case UserOptions.FILE_BANKRUPTCY:
                        Console.WriteLine("""
                                          And so it has come to this...
                                          I'm making off with the samples we already have.
                                          I know some places on the black market who will buy these rover parts.
                                          The taxman will never get me.
                                          
                                          You should start again. 
                                          Make another space agency with a new face and a new name.

                                          **Years of hiding later**


                                          """);
                        MissionControl.FileForBankRuptcy();
                        Welcome();
                        break;

                    case UserOptions.TAKE_SAMPLE:
                        UserCollectSample();
                        break;

                    case UserOptions.EXIT:
                        Environment.Exit(0);
                        break;

                }
            }
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
            for (int i = 0; i < MissionControl.Plateaus.Count; i++)
            {
                Console.WriteLine($"{i+1}. {MissionControl.Plateaus[i].ToString()}");
            }
        }

        public static void GetAllRoversAtSource(List<Rover> source)
        {
            if (source == MissionControl.Rovers)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (!source[i].isDeployed)
                    {
                        Console.WriteLine($"{i + 1}. Rover {source[i].ID}");
                    }
                }
                return;
            }
            
            for (int i = 0; i < source.Count; i++)
            {
                Console.WriteLine($"{i+1}. Rover {source[i].ID}");
            }

        }

        public static void UserDeployRover(Rover rover)
        {
            if (rover.isDeployed)
            {
                Console.WriteLine("This rover has already been deployed and cannot be redeployed.");
                return;
            }
            Console.WriteLine($"Which Plateau would you like to deploy Rover {rover.ID} to?");
            GetAllPlateaus();
            Plateau? plateauChoice = Input.ChoosePlateau();
            if (plateauChoice is null)
            {
                Console.WriteLine("Deployment cancelled.");
                return;
            }

            GetAllRoverPositionsAtPlateau(plateauChoice);
            Console.WriteLine(plateauChoice.Size.ToString());
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

        public static UserOptions GetUserOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("""
                              1. Build a new Rover
                              2. Discover a new Plateau
                              3. Deploy an existing Rover
                              4. Move a rover
                              5. Take a sample
                              6. File for bankruptcy
                              7. Exit application
                              """);
            

            bool inputIsValid = false;
            UserOptions? result = null;
            while (!inputIsValid)
            {
                Console.WriteLine("Please input the number of your choice.");
                inputIsValid = InputParser.TryParseOption(Console.ReadLine(), out result);
                if(!inputIsValid) Console.WriteLine("Input was invalid, please try again.");
            }

            return (UserOptions)result;
        }

        public static void UserMoveRover()
        {
            Console.WriteLine("Which Plateau is the rover you'd like to move roaming on?");
            GetAllPlateaus();
            Plateau? plateauChoice = Input.ChoosePlateau();

            if (plateauChoice is null)
            {
                return;
            }

            Console.WriteLine("Which rover would you like to move?");
            Rover? rover = Input.ChooseRoverAtSource(plateauChoice.Rovers);

            if (rover is null) return;

            Console.WriteLine("This rover's current position is " + rover.Position.ToString());
            Console.WriteLine("This plateau has a " + plateauChoice.Size.ToString());

            while (true)
            {
                Console.WriteLine("""
                                  Please input your movement instructions.
                                  L rotates the rover to the Left.
                                  R rotates the rover to the Right.
                                  M moves the rover forward.
                                  Type "Cancel" to cancel.
                                  """);

                string? userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("That input was invalid.");
                    continue;
                }

                if (userInput.ToUpper() == "CANCEL")
                {
                    return;
                }
                else
                {
                    try
                    {
                        rover.ReceiveInstructions(userInput);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("This rover's current position is " + rover.Position.ToString());
                Console.WriteLine("Would you like to move this rover again? Y or N");
                string? repeatChoice = Console.ReadLine();
                bool repeatChoiceIsValid = false;
                bool goAgain = false;

                while (!repeatChoiceIsValid)
                {
                    repeatChoiceIsValid = InputParser.TryGetYesOrNo(repeatChoice, out goAgain);
                    if (!repeatChoiceIsValid)
                    {
                        Console.WriteLine("That input was invalid. Please try again, Y or N");
                    }
                }

                if (goAgain) continue;
                else return;
            }
        }

        public static void UserCollectSample()
        {
            Console.WriteLine("Which Plateau would you like to collect a sample from?");
            GetAllPlateaus();
            Plateau? plateauChoice = Input.ChoosePlateau();

            if (plateauChoice is null) return;

            if (plateauChoice.Rovers.Count == 0)
            {
                Console.WriteLine("There are no rovers at this Plateau to collect a sample! Consider deploying a rover.");
                return;
            }

            Console.WriteLine("Which Rover should collect the sample?");
            Rover? roverChoice = Input.ChooseRoverAtSource(plateauChoice.Rovers);

            if (roverChoice is null) return;

            roverChoice.CollectSample();

            Console.WriteLine(plateauChoice.Samples[^1].ToString());
        }
    }
}
