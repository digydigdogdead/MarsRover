using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover;

namespace MarsRover.InputClasses
{
    internal static class Input
    {
        public static Plateau? ChoosePlateau()
        {
            Console.WriteLine("Please choose a Plateau or type \"Cancel\" to cancel.");
            string? userInput = Console.ReadLine();

            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("You must input a number or cancel.");
                return ChoosePlateau();
            }

            if (userInput.ToLower() == "cancel")
            {
                return null;
            }

            bool isNumber = Int32.TryParse(userInput, out var number);

            if (!isNumber)
            {
                Console.WriteLine("Input was not a number. Please try again.");
                return ChoosePlateau();
            }

            if (number > MissionControl.Plateaus.Count || number < 1)
            {
                Console.WriteLine("That Plateau does not exist. Please try again.");
                return ChoosePlateau();
            }

            return MissionControl.Plateaus[number - 1];
        }
    }
}
