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
    /// Abalone is a board game designed by Michel Lalet and Laurent Lévi in 1987. 
    /// There are multiple variations of Abalone where maximum six players can play
    /// together.
    /// <seealso cref="http://www.gamerz.net/pbmserv/abalone.html"/>
    /// <para>
    /// <h2>Object of the game</h2>
    /// On a hexagonal board (radius 5) two to six players have armies of marbles. 
    /// Players take turns "pushing" 1, 2 or 3 linearly connected marbles, attempting to 
    /// push their opponents' marbles off the board. First player to push 6 of their 
    /// opponent's marbles off the board wins. In the 3+ player version, the 6 marbles 
    /// may be any combination of 6 opponents' marbles.
    /// </para>
    /// <para>
    /// <h2>Initial board layout</h2>
    /// This is the standard two player layout.
    ///        o o o o o
    ///       o o o o o o
    ///      . . o o o . .
    ///     . . . . . . . .
    ///    . . . . . . . . .
    ///     . . . . . . . .
    ///      . . x x x . .
    ///       x x x x x x
    ///        x x x x x
    /// </para>
    /// <para>
    /// <h2>Movement</h2>
    /// You may move a group of 1, 2, or 3 adjacent marbles of your color (a group of 3 
    /// marbles must be in a straight line) one space in any one of the six possible directions.
    /// </para>
    /// </summary>
    public class AbaloneGame : BoardGame
    {
        ///// <summary>
        ///// Get or set the outer border of the game board
        ///// </summary>
        //public RegularHexagon OuterBorder { get; set; }

        ///// <summary>
        ///// The inner main board of the game board
        ///// </summary>
        //public RegularHexagon InnerBorder { get; set; }

        ///// <summary>
        ///// The 2D translation matrix for the game board which calculates the
        ///// positions of each cells of the game board
        ///// </summary>
        //public Translation2DArray BoardMapWithCentre { get; set; }

        /// <summary>
        /// Get the circlar tile object
        /// </summary>
        public CircleTiling Tile
        {
            get
            {
                return (CircleTiling)this.InnerBoard.Tile;
            }
        }

        /// <summary>
        /// The Abalone game arguments passed
        /// </summary>
        /// <param name="args"></param>
        public AbaloneGame(AbaloneBoardGameArgs args)
            : this(args.Center, args.Radius, args.CirclesPerSide, args.BorderBeam) { }

        /// <summary>
        /// Basic constructor to construct an abalone board
        /// </summary>
        /// <param name="center">The center of the board</param>
        /// <param name="radius">The radial length from the center</param>
        /// <param name="circlePerSide">The circlular tiles each side of the biard</param>
        /// <param name="borderBeam">The border length of the board</param>
        public AbaloneGame(CCPoint2D center, double radius, int circlePerSide = 5, double borderBeam = 10)
        {
            CCSpan span = new CCSpan(center, radius);
            CircleTiling tiling = new CircleTiling(circlePerSide);

            this.Initialize(span, tiling, borderBeam);
        }

        /// <summary>
        /// The method to initialze the Abalone Game board
        /// You can reinitialize the same object using this function
        /// </summary>
        /// <param name="span"></param>
        /// <param name="tile"></param>
        /// <param name="borderBeam"></param>
        public void Initialize(CCSpan span, CircleTiling tile, double borderBeam)
        {
            this.OuterBorder = new RegularHexagon(span);

            this.InnerBoard = new RegularHexagon(new CCSpan(span.Center, span.RadialWidth - borderBeam));
            this.InnerBoard.SetTiling(tile);

            CalculateTranslationMatrix();
            CalculateCircleCentres();
            CalculateOuterHexagon();
        }

        /// <summary>
        /// Calculate the ouetr hexagon
        /// </summary>
        private void CalculateOuterHexagon()
        {
            this.OuterBorder.CalculateCoordinates();
            this.InnerBoard.CalculateCoordinates();
        }

        /// <summary>
        /// Calculate the translation matrix
        /// </summary>
        private void CalculateTranslationMatrix()
        {
            TranslationMatrixCells = new Translation2DArray(this.Tile.Properties.Rows);
            int countCircles = this.Tile.NoOfCirclesPerSide;

            for (int y = (-1) * (countCircles - 1), indx1 = 0; y <= (countCircles - 1); ++y, indx1++)
            {
                int noOfCols = this.Tile.Properties.Rows - Math.Abs(y);
                TranslationMatrixCells.SetupColumn(indx1, noOfCols);

                for (int x = (-1) * (noOfCols - 1), indx2 = 0; x <= (noOfCols - 1); x += 2, indx2++)
                {
                    TranslationMatrixCells.SetValue(indx1, indx2, new CCPoint2D(x, y));
                }
            }
        }

        private void CalculateCircleCentres()
        {
            this.Tile.CellCenters = new Plane2DArray(this.Tile.Properties.Rows);

            for (int x = 0; x < this.TranslationMatrixCells.GetRowsCount(); x++)
            {
                this.Tile.CellCenters.Factors[x] = new CCPoint2D[this.TranslationMatrixCells.GetColumnCount(x)];
                for (int y = 0; y < this.TranslationMatrixCells.GetColumnCount(x); y++)
                {
                    this.Tile.CellCenters.Factors[x][y] = new CCPoint2D((float)(this.OuterBorder.Locate.Center.X + this.TranslationMatrixCells.Factors[x][y].X * this.InnerBoard.UnitOfMeasure.X),
                        (float)(this.OuterBorder.Locate.Center.Y + this.TranslationMatrixCells.Factors[x][y].Y * this.InnerBoard.UnitOfMeasure.Y));
                }
            }
        }

        public override void ToOutput(IOutStream stream)
        {
            base.ToOutput(stream);
            
            ToOutputOuterBorder(stream);
            ToOutputMainBoard(stream);
        }

        public override void ToOutputMainBoard(IOutStream stream)
        {
            InnerBoard.ToOutput(stream);
        }

        public override void ToOutputOuterBorder(IOutStream stream)
        {
            OuterBorder.ToOutput(stream);
        }
    }
}
