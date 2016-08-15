using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class SVGStream : OutPutStream
    {
        public SVGStream(string name)
            : base(name)
        {
        }

        public override void Initialize()
        {
            this.writer.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>");
            this.writer.AppendLine(@"<?xml-stylesheet href=""abalone-board.css"" type=""text/css""?>");
            this.writer.AppendLine(@"<!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">");
        }

        public override void Start()
        {
            base.Start();
            this.writer.AppendLine(@"<svg baseProfile=""full"" width=""500"" height=""500"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">");
        }

        public override void End()
        {
            this.writer.AppendLine(@"</svg>");
            base.End();
        }

        public override void AddCircle(CCPoint cCPoint, double radius)
        {
            base.AddCircle(cCPoint, radius);
            this.writer.AppendLine(string.Format(@"<circle cx=""{0}"" cy=""{1}"" r=""{2}"" class=""cell"" />",
                        cCPoint.X, cCPoint.Y, radius));
        }

        public override void AddPolygon(CCPoint[] cCPoints)
        {
            base.AddPolygon(cCPoints);
            this.writer.Append(@"<polygon points=""");
            this.writer.Append(string.Join(",", cCPoints.Select(p => string.Format("{0},{1}", p.X, p.Y))));
            this.writer.AppendLine(@"""></polygon>");
        }
    }
}
