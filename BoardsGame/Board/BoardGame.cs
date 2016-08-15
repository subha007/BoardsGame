using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class BoardGame : IBoardGame
    {
        public virtual void ToOutput(OutPutStream stream)
        {

        }

        public virtual void ToOutputMainBoard(OutPutStream stream)
        {
            
        }

        public virtual void ToOutputOuterBorder(OutPutStream stream)
        {
            
        }
    }
}
