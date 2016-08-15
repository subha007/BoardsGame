using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Translation2DArray
    {
        public CCPoint[][] Factors { get; set; }

        public Translation2DArray(int rows)
        {
            this.Factors = new CCPoint[rows][];
        }
    }
}
