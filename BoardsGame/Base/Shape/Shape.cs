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
    public class Shape : IShape2D
    {
        #region Properties

        /// <summary>
        /// Number of vertices is equal to number of edges
        /// </summary>
        public int NoOfVertices { get; set; }

        /// <summary>
        /// The span of the shape alongwith the origin
        /// </summary>
        public CCSpan Locate { get; set; }

        /// <summary>
        /// Any tiling shapes if defined
        /// </summary>
        public ITiling2D Tile { get; set; }

        /// <summary>
        /// The unit of measuremnt used
        /// </summary>
        public CCUnit2D UnitOfMeasure { get; set; }

        /// <summary>
        /// The vertcies coordinates
        /// </summary>
        public CCPoint2D[] Vertices { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Basic constructor to define the shape with number of vertices
        /// </summary>
        /// <param name="vertices"></param>
        public Shape(int vertices)
        {
            this.NoOfVertices = vertices;
            this.Initialize();
        }

        /// <summary>
        /// A constructor to define the shape and size both of the 2D Shape
        /// </summary>
        /// <param name="vertices">The number of vertices</param>
        /// <param name="locate">The location</param>
        public Shape(int vertices, CCSpan locate)
        {
            this.NoOfVertices = vertices;

            this.Initialize();
            this.SetLocation(locate);
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Initialize data
        /// </summary>
        protected virtual void Initialize()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the span of the shape alongwith the origin.
        /// Modifies the property <see cref="Locate"/>
        /// </summary>
        /// <param name="locate"></param>
        public virtual void SetLocation(CCSpan locate)
        {
            this.Locate = locate;
        }

        /// <summary>
        /// Set any tiling shape.
        /// Modifies the property <see cref="Tile"/>
        /// </summary>
        /// <param name="tile"></param>
        public virtual void SetTiling(ITiling2D tile)
        {
            this.Tile = tile;
        }

        /// <summary>
        /// Calculate the coordinates
        /// </summary>
        public virtual void CalculateCoordinates()
        {
            
        }

        /// <summary>
        /// Set the output data stream
        /// </summary>
        /// <param name="stream"></param>
        public virtual void ToOutput(IOutStream stream)
        {
            if (this.Tile != null)
                this.Tile.ToOutput(stream);
        }

        #endregion
    }
}
