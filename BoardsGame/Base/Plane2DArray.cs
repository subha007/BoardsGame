﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Plane2DArray
    {
        public CCPoint[][] Factors { get; set; }

        public Plane2DArray(int rows)
        {
            this.Factors = new CCPoint[rows][];
        }
    }
}
