using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class GameBoardFactory
    {
        public BoardGame GenerateBoard(EnvArgumentsEngine args)
        {
            BoardGame bgame = null;
            BoardGameArgs bgameArgs = null;

            switch(args.Options.Board)
            {
                case "abalone":
                    bgameArgs = new AbaloneBoardGameArgs(args);
                    bgame = new AbaloneGame((AbaloneBoardGameArgs)bgameArgs);
                    break;

                default:
                    break;
            }

            return bgame;
        }
    }
}
