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
    /// The interface to define a component of the Game Board
    /// Follows the Composite Design Pattern.
    /// </summary>
    public interface IComponent
    {
        #region Properties

        /// <summary>
        /// Get or set the name of the component
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set the position in the matrix of components in a composition
        /// If it is root or lone element by default indices are 0.
        /// </summary>
        public Matrix2DPosition MatrixPos { get; set; }

        /// <summary>
        /// Calculate the center of the component
        /// </summary>
        public CCPoint2D Center { get; set; }

        #endregion

        #region IComponent

        /// <summary>
        /// Add a new Component
        /// </summary>
        /// <param name="c"></param>
        void Add(IComponent c);

        /// <summary>
        /// Remove an existing component from the list
        /// </summary>
        /// <param name="c"></param>
        void Remove(IComponent c);

        /// <summary>
        /// Get a list of all child under the component in the 2D plane
        /// </summary>
        /// <returns></returns>
        Matrix2D<IComponent> GetChild();

        /// <summary>
        /// Get the child under the component at a particular index in the 2D plane
        /// </summary>
        /// <param name="indx">The index in the array</param>
        /// <returns></returns>
        IComponent GetChild(Matrix2DPosition pos);

        #endregion
    }
}
