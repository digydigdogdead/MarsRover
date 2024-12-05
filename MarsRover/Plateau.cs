using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public PlateauSize Size { get; }
        public List<Rover> Rovers { get; private set; } = new List<Rover>();
        public string Name { get; set; }


        public Plateau(PlateauSize size, string name)
        {
            Size = size;
            Name = name;
        }

        public void AddRover(Rover rover)
        {
            Rovers.Add(rover);
            rover.Plateau = this;
        }

        public void RemoveRover(Rover rover)
        {
            if (!Rovers.Contains(rover)) throw new NullReferenceException("That Rover is not present in this Plateau");

            Rovers.Remove(rover);
            rover.Plateau = null;
        }


        public override string ToString()
        {
            return $"{Name} Plateau.";
        }

    }
}
