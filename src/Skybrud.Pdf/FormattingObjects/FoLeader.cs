using System;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoLeader : FoElement {
        
        public string Pattern;
        public string Length;
        public string Thickness;
        public string Color;

        public static FoLeader HorizontalRuler {
            get { return new FoLeader { Pattern = "rule", Length = "100%", Thickness = "1px" }; }
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xLeader = new XElement(FoDocument.Namespace + "leader");
            if (!String.IsNullOrEmpty(Pattern)) xLeader.Add(new XAttribute("leader-pattern", Pattern));
            if (!String.IsNullOrEmpty(Length)) xLeader.Add(new XAttribute("leader-length", Length));
            if (!String.IsNullOrEmpty(Thickness)) xLeader.Add(new XAttribute("rule-thickness", Thickness));
            if (!String.IsNullOrEmpty(Color)) xLeader.Add(new XAttribute("color", Color));
            return xLeader;
        }

    }

}