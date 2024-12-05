using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class PlateauSize
    {
        public int Xsize {  get; set; }
        public int Ysize { get; set; }

        public PlateauSize(int x, int y)
        {
            Xsize = x;
            Ysize = y;
        }

        public override string ToString()
        {
            return $"Plateau Size of ({Xsize}, {Ysize})";
        }
    }
}
