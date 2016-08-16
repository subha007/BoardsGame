using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class InnerBoardMatrix2D<InnerBoardClass, CellClass, CellMarkerClass>
    {
        public InnerBoardMatrix2D<InnerBoardClass, CellClass, CellMarkerClass> InnerBoards { get; set; }
        public BoardCellMatrix2D<CellClass, CellMarkerClass> InnerBoardCellMatrix { get; set; }
        public Board2DCellPack CellPackInfo { get; set; }
    }
}
