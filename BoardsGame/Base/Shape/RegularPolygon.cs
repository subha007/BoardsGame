#region License

// IShape2D.cs
// Copyright (c) 2016, Subhadeep Niogi
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list
// of conditions and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this 
// list of conditions and the following disclaimer in the documentation and/or other
// materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BoardsGame
{
    /// <summary>
    /// The regular polygon shape in 2D
    /// </summary>
    public class RegularPolygon : Shape
    {
        /// <summary>
        /// The interior angle of the polygon. It is an angle made between the Centre and the
        /// opposite edge
        /// </summary>
        public double InteriorAngle { get; set; }

        /// <summary>
        /// The exterior angle. It is an angle made between two edges
        /// </summary>
        public double ExteriorAngle { get; set; }

        /// <summary>
        /// Radius of the incircle is the Apothem of the polygon
        /// </summary>
        public double InCircleRadius { get; set; }

        /// <summary>
        /// The length of a side
        /// </summary>
        public double SideLength { get; set; }

        /// <summary>
        /// The radius of the outcircle
        /// </summary>
        public double OutCircleRadius { get; set; }

        /// <summary>
        /// Base constructor initialize a basic regular polygon
        /// </summary>
        /// <param name="vertices"></param>
        public RegularPolygon(int vertices)
            : base(vertices)
        {
        }

        /// <summary>
        /// Base constructor initialize a basic regular polygon
        /// </summary>
        /// <param name="vertices"></param>
        public RegularPolygon(int vertices, CCSpan locate)
            : base(vertices, locate)
        {
        }

        /// <summary>
        /// Initializes the object
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.ExteriorAngle = 2 * Math.PI / this.NoOfVertices;
            this.InteriorAngle = (this.NoOfVertices - 2) * Math.PI / 2;
        }

        /// <summary>
        /// Set the location information
        /// </summary>
        /// <param name="locate"></param>
        public override void SetLocation(CCSpan locate)
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

            this.UnitOfMeasure = new CCUnit2D(tile.Radius,
                                    tile.Radius * Math.Tan(this.ExteriorAngle));

        }

        public override void CalculateCoordinates()
        {
            base.CalculateCoordinates();

            Vertices = new CCPoint2D[this.NoOfVertices];
            for (int i = 0; i < this.NoOfVertices; i++)
            {
                Vertices[i] = new CCPoint2D(
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
