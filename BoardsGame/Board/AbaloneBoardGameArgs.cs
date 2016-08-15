using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class AbaloneBoardGameArgs : BoardGameArgs
    {
        public int CirclesPerSide { get; set; }
        public double BorderBeam { get; set; }

        public AbaloneBoardGameArgs(EnvArgumentsEngine args)
            : base(args) 
        {
            this.CirclesPerSide = 5;
            this.BorderBeam = 0;
        }

        protected override void Initialize(EnvArgumentsEngine args)
        {
            base.Initialize(args);

            if (string.IsNullOrEmpty(args.Options.CirclesPerSide))
            {
                this.CirclesPerSide = Convert.ToInt32(args.Options.CirclesPerSide);
            }

            if (string.IsNullOrEmpty(args.Options.BorderBeam))
            {
                this.BorderBeam = Convert.ToDouble(args.Options.BorderBeam);
            }
        }
    }
}
