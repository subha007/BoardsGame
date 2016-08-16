#region License

// BoardsGame.cs
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
    /// A Tile of Circles
    /// </summary>
    public class CircleTiling : Tiling
    {
        /// <summary>
        /// Gets or sets the number of circles per side of a regular shaped figure
        /// </summary>
        public int NoOfCirclesPerSide { get; set; }

        /// <summary>
        /// The radius of the circles
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="count">The number of circles per side</param>
        /// <param name="radius">The radius of the circles</param>
        public CircleTiling(int count, double radius = 0)
        {
            this.NoOfCirclesPerSide = count;
            this.Radius = radius;

            InitializeProperty();
        }

        /// <summary>
        /// The method calculates the corrected radial length of the regular shape 
        /// </summary>
        /// <returns></returns>
        public double ActualRadialLength()
        {
            return this.Radius * (2 * this.NoOfCirclesPerSide - 1);
        }

        /// <summary>
        /// Calculate the count of circles row / column span of a matrix 
        /// </summary>
        public void InitializeProperty()
        {
            this.Properties = new Array2DProperty(this.NoOfCirclesPerSide * 2 - 1, this.NoOfCirclesPerSide * 2 - 1);
        }

        /// <summary>
        /// Output circles data to the output stream
        /// </summary>
        /// <param name="stream"></param>
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
