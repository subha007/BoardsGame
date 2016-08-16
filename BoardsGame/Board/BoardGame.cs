using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class BoardGame : IBoardGame
    {
        /// <summary>
        /// Get or set the outer border of the game board
        /// </summary>
        public IShape2D OuterBorder { get; set; }

        /// <summary>
        /// The inner main board of the game board
        /// </summary>
        public IShape2D InnerBoard { get; set; }

        /// <summary>
        /// The 2D translation matrix for the game board which calculates the
        /// positions of each cells of the game board
        /// </summary>
        public Translation2DArray TranslationMatrixCells { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public virtual void ToOutput(IOutStream stream)
        {

        }

        public virtual void ToOutputMainBoard(IOutStream stream)
        {
            
        }

        public virtual void ToOutputOuterBorder(IOutStream stream)
        {
            
        }
    }
}
