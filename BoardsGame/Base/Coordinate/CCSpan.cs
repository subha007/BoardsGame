#region License

// CCPoint.cs
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
    /// The most basic 2D shape identifier in a plane.
    /// The idea is to define the center of Gravity of the shape, and
    /// The avergae span from the center to the side. <see cref="Shape"/>
    /// For a regular geometric shape it is equivalent in all direction.
    /// </summary>
    public class CCSpan
    {
        /// <summary>
        /// The center of the shape
        /// </summary>
        public CCPoint2D Center { get; set; }

        /// <summary>
        /// The radial disatnce from the centre to one side along X Axis
        /// </summary>
        public double RadialWidth { get; set; }

        /// <summary>
        /// The radial disatnce from the centre to one side along Y Axis
        /// </summary>
        public double RadialHeight { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="center">The center of the <see cref="Shape"/></param>
        /// <param name="radialwidth">The X axis span from center. Default value is <value>0</value></param>
        /// <param name="radialheight">The Y axis span from center. Default value is <value>0</value></param>
        public CCSpan(CCPoint2D center, double radialwidth = 0, double radialheight = 0)
        {
            this.Center = center;
            this.RadialWidth = radialwidth;
            this.RadialHeight = radialheight;
        }

        /// <summary>
        /// Constructor of a shape which has regular span on both X and Y direction
        /// </summary>
        /// <param name="center">The center of the <see cref="Shape"/></param>
        /// <param name="radial">The radial distance.</param>
        public CCSpan(CCPoint2D center, double radial)
            : this(center, radial, radial)
        {
        }
    }
}
