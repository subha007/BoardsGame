using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class AbaloneGame : BoardGame
    {
        public RegularHexagon OuterBorder { get; set; }
        public RegularHexagon InnerBorder { get; set; }
        public Translation2DArray BoardMapWithCentre { get; set; }

        public CircleTiling Tile
        {
            get
            {
                return (CircleTiling)this.InnerBorder.Tile;
            }
        }

        public AbaloneGame(AbaloneBoardGameArgs args)
            : this(args.Center, args.Radius, args.CirclesPerSide, args.BorderBeam) { }

        public AbaloneGame(CCPoint center, double radius, int circlePerSide = 5, double borderBeam = 10)
        {
            CCSpan span = new CCSpan(center, radius);
            CircleTiling tiling = new CircleTiling(circlePerSide);

            this.Initialize(span, tiling, borderBeam);
        }

        public AbaloneGame(CCSpan span, CircleTiling tile, double borderBeam = 10)
        {
            
        }

        public void Initialize(CCSpan span, CircleTiling tile, double borderBeam)
        {
            this.OuterBorder = new RegularHexagon();
            this.OuterBorder.SetLocation(span);

            this.InnerBorder = new RegularHexagon();
            this.InnerBorder.SetLocation(new CCSpan(span.Center, span.RadialWidth - borderBeam));
            this.InnerBorder.SetTiling(tile);

            CalculateTranslationMatrix();
            CalculateCircleCentres();
            CalculateOuterHexagon();
        }

        private void CalculateOuterHexagon()
        {
            this.OuterBorder.Calculate();
            this.InnerBorder.Calculate();
        }

        /// <summary>
        /// Calculate the translation matrix
        /// </summary>
        private void CalculateTranslationMatrix()
        {
            BoardMapWithCentre = new Translation2DArray(this.Tile.Properties.Rows);
            int countCircles = this.Tile.NoOfCirclesPerSide;

            for (int y = (-1) * (countCircles - 1), indx1 = 0; y <= (countCircles - 1); ++y, indx1++)
            {
                int noOfCols = this.Tile.Properties.Rows - Math.Abs(y);
                BoardMapWithCentre.Factors[indx1] = new CCPoint[noOfCols];

                for (int x = (-1) * (noOfCols - 1), indx2 = 0; x <= (noOfCols - 1); x += 2, indx2++)
                {
                    BoardMapWithCentre.Factors[indx1][indx2] = new CCPoint(x, y);
                }
            }
        }

        private void CalculateCircleCentres()
        {
            this.Tile.CellCenters = new Plane2DArray(this.Tile.Properties.Rows);

            for (int x = 0; x < this.BoardMapWithCentre.Factors.GetLength(0); x++)
            {
                this.Tile.CellCenters.Factors[x] = new CCPoint[this.BoardMapWithCentre.Factors[x].Length];
                for (int y = 0; y < this.BoardMapWithCentre.Factors[x].Length; y++)
                {
                    this.Tile.CellCenters.Factors[x][y] = new CCPoint((float)(this.OuterBorder.Locate.Center.X + this.BoardMapWithCentre.Factors[x][y].X * this.InnerBorder.UnitOfMeasure.X),
                        (float)(this.OuterBorder.Locate.Center.Y + this.BoardMapWithCentre.Factors[x][y].Y * this.InnerBorder.UnitOfMeasure.Y));
                }
            }
        }

        public override void ToOutput(OutPutStream stream)
        {
            base.ToOutput(stream);
            
            ToOutputOuterBorder(stream);
            ToOutputMainBoard(stream);
        }

        private void ToOutputMainBoard(OutPutStream stream)
        {
            InnerBorder.ToOutput(stream);
        }

        private void ToOutputOuterBorder(OutPutStream stream)
        {
            OuterBorder.ToOutput(stream);
        }
    }
}
