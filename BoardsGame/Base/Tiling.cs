using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Tiling
    {
        public Array2DProperty Properties { get; set; }
        public Plane2DArray CellCenters { get; set; }

        public virtual void ToOutput(OutPutStream stream)
        {
            // 
        }
    }
}
