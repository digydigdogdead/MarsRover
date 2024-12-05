using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Plateau
    {
        public PlateauSize Size { get; }
        public List<Rover> Rovers { get; set; }
    }
}
