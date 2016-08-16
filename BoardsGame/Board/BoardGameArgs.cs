using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class BoardGameArgs
    {
        public CCPoint2D Center { get; protected set; }
        public double Radius { get; set; }

        public BoardGameArgs(EnvArgumentsEngine args)
        {
            Initialize(args);
        }

        protected virtual void Initialize(EnvArgumentsEngine args)
        {
            string[] split = args.Options.Center.Split(new char[] { ',' }).Select(x => x.Trim()).ToArray();

            this.Center = new CCPoint2D();
            this.Center.X = Convert.ToDouble(split[0]);
            this.Center.Y = Convert.ToDouble(split[1]);

            this.Radius = Convert.ToDouble(args.Options.Radius);
        }
    }
}
