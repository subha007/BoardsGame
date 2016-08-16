using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class AbaloneBoardCSSCreator : CSSCreator
    {
        public string CellClassName { get; set; }
        public string OuterBorderClassName { get; set; }
        public string InnerBorderClassName { get; set; }
        public List<string> PlayerClassName { get; set; }

        public List<string> CellPropeties { get; set; }
        public List<string> OuterBorderPropeties { get; set; }
        public List<string> InnerBorderPropeties { get; set; }

        public AbaloneBoardCSSCreator()
        {
            this.CellClassName = "cell";
            this.OuterBorderClassName = "outer_border";
            this.InnerBorderClassName = "inner_border";
        }

        public void Initialize()
        {
            this.CellPropeties = new string[] {
                "fill: transparent",
                "stroke: red",
                "stroke-width: 1"
            }.ToList();

            this.OuterBorderPropeties = new string[]{
                "fill: transparent",
                "stroke: blue",
                "stroke-width: 1"
            }.ToList();

            this.InnerBorderPropeties = new string[]{
                "fill: transparent",
                "stroke: blue",
                "stroke-width: 1"
            }.ToList();
        }
    }
}
