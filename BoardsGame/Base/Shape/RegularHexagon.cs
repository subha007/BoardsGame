using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class RegularHexagon : RegularPolygon
    {
        public RegularHexagon() : base(6) { }

        public RegularHexagon(CCSpan locate) : base(6, locate) { }
    }
}
