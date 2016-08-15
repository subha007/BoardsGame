using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class OutputStreamFactory
    {
        public OutPutStream GenerateStream(EnvArgumentsEngine args)
        {
            OutPutStream stream = null;

            switch(args.Options.OutputType)
            {
                case "svg":
                    stream = new SVGStream(args.Options.FilePath);
                    break;

                default:
                    break;
            }

            return stream;
        }
    }
}
