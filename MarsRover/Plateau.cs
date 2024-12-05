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
        public List<Rover> Rovers { get; set; } = new List<Rover>();
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


        public override string ToString()
        {
            return $"{Name} Plateau.";
        }

    }
}
