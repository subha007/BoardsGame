using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class Shape
    {
        public CCSpan Locate { get; set; }
        public Tiling Tile { get; set; }

        protected void SetLocation(CCSpan locate)
        {
            this.Locate = locate;
        }

        public void SetTiling(Tiling tile)
        {
            this.Tile = tile;
        }

        public virtual void ToOutput(OutPutStream stream)
        {
            if (this.Tile != null)
                this.Tile.ToOutput(stream);
        }
    }
}
