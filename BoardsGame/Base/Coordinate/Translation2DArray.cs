using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Translation2DArray
    {
        public CCPoint2D[][] Factors { get; set; }

        public Translation2DArray(int rows)
        {
            this.Factors = new CCPoint2D[rows][];
        }

        public int GetRowsCount()
        {
            return this.Factors.GetLength(0);
        }

        public int GetColumnCount(int rowIndex)
        {
            return this.Factors[rowIndex].Length; 
        }

        public void SetupColumn(int rowIndex, int colCount)
        {
            this.Factors[rowIndex] = new CCPoint2D[colCount];
        }

        public void SetValue(int rIndx, int cIndx, CCPoint2D value)
        {
            this.Factors[rIndx][cIndx] = value;
        }
    }
}
