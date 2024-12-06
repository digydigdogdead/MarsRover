using MarsRover;
using MarsRover.InputClasses;
using MarsRover.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        /*        PlateauSize testSize = Creator.CreatePlateauSize("5 5");
                Position testPosition = Creator.CreatePosition("1 2 N");
                Plateau plateau = new Plateau(testSize, "The Red Wastes");
                Rover rover1 = new Rover();

                MissionControl.DeployRover(rover1, plateau, testPosition);

                Console.WriteLine(rover1.Position.ToString());

                rover1.ReceiveInstructions("RMMLMM");

                Console.WriteLine(rover1.Position.ToString());

                rover1.ReceiveInstructions("MMMMMMMMMMMM");

                Console.WriteLine(rover1.Position.ToString());*/

        UI.Welcome();

/*        List<Sample> samples = new List<Sample>();
        for (int i = 0; i < 1000; i++)
        { 
            Sample sample = new Sample();
            samples.Add(sample);
        }
        foreach (Sample sample in samples)
        {
            Console.WriteLine(sample.ToString());
        }*/
    }
}