using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public PlateauSize Size { get; private set; }
        public List<Rover> Rovers { get; private set; } = new List<Rover>();
        public string Name { get; set; }
        public int MaximumCapacity { get; set; }

        public Plateau(int sizex, int sizey, string name)
        {
            PlateauSize size = new PlateauSize(sizex, sizey);
            SetUpPlateau(size, name);
        }
        public Plateau(PlateauSize size, string name)
        {
            SetUpPlateau(size, name);
        }

        private void SetUpPlateau(PlateauSize size, string name)
        {
            Size = size;
            Name = name;
            MaximumCapacity = Size.Xsize * Size.Ysize;
            MissionControl.Plateaus.Add(this);
        }

        public void AddRover(Rover rover)
        {
            if (Rovers.Count == MaximumCapacity)
            {
                Console.WriteLine("Cannot add more rovers to this Plateau. It is full.");
                return;
            }

            if (rover.Plateau == this)
            {
                Console.WriteLine("This Rover is already at this location.");
                return;
            }
            
            Rovers.Add(rover);
            rover.Plateau = this;
        }

        public void RemoveRover(Rover rover)
        {
            if (!Rovers.Contains(rover)) throw new NullReferenceException("That Rover is not present in this Plateau");

            Rovers.Remove(rover);
            rover.Plateau = null;
        }

        public bool CheckPositionIsFree(Position position)
        {
            if (position.X > Size.Xsize - 1 || position.Y > Size.Ysize - 1)
            {
                return false;
            }
            
            foreach (var rover in Rovers)
            {
                if (rover.Position.X == position.X && rover.Position.Y == position.Y) return false;
            }

            return true;
        }


        public override string ToString()
        {
            return $"{Name} Plateau.";
        }

    }
}
