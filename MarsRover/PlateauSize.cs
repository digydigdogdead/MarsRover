using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class PlateauSize
    {
        public int Xsize {  get; set; }
        public int Ysize { get; set; }

        public PlateauSize(int x, int y)
        {
            Xsize = x;
            Ysize = y;
        }
    }
}
