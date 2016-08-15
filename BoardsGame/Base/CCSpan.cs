using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class CCSpan
    {
        public CCPoint Center { get; set; }
        public double RadialWidth { get; set; }
        public double RadialHeight { get; set; }

        public CCSpan(CCPoint center, double radialwidth = 0, double radialheight = 0)
        {
            this.Center = center;
            this.RadialWidth = radialwidth;
            this.RadialHeight = radialheight;
        }

        public CCSpan(CCPoint center, double radial)
            : this(center, radial, radial)
        {
        }
    }
}
