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


        }

        public static void GetAllPlateaus()
        {
           
        }
    }
}
