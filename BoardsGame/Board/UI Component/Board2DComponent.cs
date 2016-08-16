#region License

// IComponent.cs
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
    /// The class represents a component of the 2D Game Board. A Game Board can
    /// have a Outer Border and a List of Inner Boards.
    /// Each Inner Boards can Contain Outer Border and List of further inner boards.
    /// It also contains Individual Cells where the pieces are placed or the players
    /// It may contain cell markers, Scoreboard, and lots of other Game stuffs.
    /// </summary>
    public class Board2DComponent : IComponent
    {
        #region Properties

        /// <summary>
        /// Get or set the name of the component
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get the list of descendents / components
        /// </summary>
        public Matrix2D<IComponent> Descendents { get; protected set; }

        /// <summary>
        /// Get or set the position in the matrix of components in a composition
        /// If it is root or lone element by default indices are 0.
        /// </summary>
        public Matrix2DPosition MatrixPos { get; set; }

        /// <summary>
        /// Get or set the marker with respect to the Game
        /// </summary>
        public Board2DMarker Marker { get; set; }

        /// <summary>
        /// Get or set the shape of the component
        /// </summary>
        public IShape2D GeometryShape { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Basic constructor
        /// </summary>
        public Board2DComponent()
        {
            this.Descendents = new Matrix2D<IComponent>();
        }

        /// <summary>
        /// Basic constructor for initializing only row for matrix
        /// </summary>
        public Board2DComponent(int rows)
        {
            this.Descendents = new Matrix2D<IComponent>(rows);
        }

        /// <summary>
        /// Basic constructor for initializing the descendents matrix
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Board2DComponent(int rows, int cols)
        {
            this.Descendents = new Matrix2D<IComponent>(rows, cols);
        }

        #endregion

        #region IComponent

        /// <summary>
        /// Add a new Component if not exists in the Component List
        /// </summary>
        /// <param name="c"></param>
        public void Add(IComponent c)
        {
            this.Descendents.Add(c.MatrixPos, c);
        }

        /// <summary>
        /// Remove an existing component from the list
        /// </summary>
        /// <param name="c"></param>
        public void Remove(IComponent c)
        {
            this.Descendents.Remove(c.MatrixPos);
        }

        /// <summary>
        /// Get a list of all child under the component in the 2D plane
        /// </summary>
        /// <returns></returns>
        public Matrix2D<IComponent> GetChild()
        {
            return this.Descendents;
        }

        /// <summary>
        /// Get the child under the component at a particular index in the 2D plane
        /// </summary>
        /// <param name="indx">The index in the array</param>
        /// <returns></returns>
        public IComponent GetChild(Matrix2DPosition pos)
        {
            return this.Descendents.GetData(pos);
        }

        #endregion
    }
}
