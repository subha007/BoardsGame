using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class BoardCellMatrix2D<CellClass, CellMarkerClass> where CellClass : new()
    {
        public CellClass[][] Cells { get; set; }
        public CellMarkerClass Marker { get; set; }
    }
}
