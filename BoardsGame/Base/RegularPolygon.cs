using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class RegularPolygon : Shape
    {
        /// <summary>
        /// Number of vertices is equal to number of edges
        /// </summary>
        public int NoOfVertices { get; set; }
        public double InteriorAngle { get; set; }
        public double ExteriorAngle { get; set; }

        /// <summary>
        /// Radius of the incircle is the Apothem of the polygon
        /// </summary>
        public double InCircleRadius { get; set; }
        public double SideLength { get; set; }
        public double OutCircleRadius { get; set; }

        public CCUnit UnitOfMeasure { get; set; }

        public CCPoint[] Vertices { get; set; }

        public RegularPolygon(int vertices)
        {
            this.NoOfVertices = vertices;
            Initialize();
        }

        private void Initialize()
        {
            this.ExteriorAngle = 2 * Math.PI / this.NoOfVertices;
            this.InteriorAngle = (this.NoOfVertices - 2) * Math.PI / 2;
        }

        public void SetLocation(CCSpan locate)
        {
            base.SetLocation(locate);

            this.SideLength = this.Locate.RadialWidth * 2 * Math.Sin(this.ExteriorAngle / 2);
            this.InCircleRadius = this.Locate.RadialWidth * Math.Cos(this.ExteriorAngle / 2);
            this.OutCircleRadius = this.Locate.RadialWidth;
        }

        public void SetTiling(CircleTiling tile)
        {
            tile.Radius = this.OutCircleRadius / (2 * (tile.NoOfCirclesPerSide - 1) + (1 / Math.Sin(this.ExteriorAngle)));
            base.SetTiling(tile);

            this.UnitOfMeasure = new CCUnit(tile.ActualRadialLength(),
                                    tile.ActualRadialLength() * Math.Sin(this.ExteriorAngle) / 4);

        }

        public void Calculate()
        {
            Vertices = new CCPoint[this.NoOfVertices];
            for (int i = 0; i < this.NoOfVertices; i++)
            {
                Vertices[i] = new CCPoint(
                                          (float)(this.Locate.Center.X + this.OutCircleRadius * Math.Cos((i) * this.ExteriorAngle)),
                                          (float)(this.Locate.Center.Y + this.OutCircleRadius * Math.Sin((i) * this.ExteriorAngle))
                                          );
            }
        }

        public void ToOutput(OutPutStream stream)
        {
            base.ToOutput(stream);

            // Polygon boundary
            stream.AddPolygon(Vertices);
            // 
        }
    }
}
