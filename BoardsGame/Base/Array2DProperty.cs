using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Array2DProperty
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Array2DProperty(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
        }
    }
}
