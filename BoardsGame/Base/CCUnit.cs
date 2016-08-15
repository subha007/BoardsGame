using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class CCUnit
    {
        public double X { get; set; }
        public double Y { get; set; }

        public CCUnit(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
