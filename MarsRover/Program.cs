using MarsRover;
using MarsRover.InputClasses;

internal class Program
{
    private static void Main(string[] args)
    {
        PlateauSize testSize = Creator.CreatePlateauSize("5 5");
        Position testPosition = Creator.CreatePosition("1 2 N");

        Console.WriteLine(testSize.ToString());
        Console.WriteLine(testPosition.ToString());

    }
}