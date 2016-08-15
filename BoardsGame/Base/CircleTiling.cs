using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class CircleTiling : Tiling
    {
        public int NoOfCirclesPerSide { get; set; }
        public double Radius { get; set; }

        public CircleTiling(int count, double radius = 0)
        {
            this.NoOfCirclesPerSide = count;
            this.Radius = radius;

            InitializeProperty();
        }

        public double ActualRadialLength()
        {
            return this.Radius * (this.NoOfCirclesPerSide - 1);
        }

        public void InitializeProperty()
        {
            this.Properties = new Array2DProperty(this.NoOfCirclesPerSide * 2 - 1, this.NoOfCirclesPerSide * 2 - 1);
        }

        public override void ToOutput(OutPutStream stream)
        {
            base.ToOutput(stream);

            // Add Circles
            for (int x = 0; x < this.CellCenters.Factors.GetLength(0); x++)
            {
                for (int y = 0; y < this.CellCenters.Factors[x].Length; y++)
                {
                    stream.AddCircle(this.CellCenters.Factors[x][y], this.Radius);
                }
            }
        }
    }
}
