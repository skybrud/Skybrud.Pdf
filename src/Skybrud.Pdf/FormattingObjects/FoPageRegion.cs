using System;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoPageRegion : FoElement {

        public string Name { get; set; }
        public string Type { get; private set; }
        public string BackgroundRepeat { get; set; }
        public string BackgroundImage { get; set; }
        public int ColumnCount { get; set; }
        public string ColumnGap { get; set; }
        public string Extent { get; set; }
        public string Margin { get; set; }
        public string MarginTop { get; set; }
        public string MarginRight { get; set; }
        public string MarginBottom { get; set; }
        public string MarginLeft { get; set; }

        public FoPageRegion(string type) {
            Type = type;
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xMaster = new XElement(FoDocument.Namespace + "region-" + Type);
            if (!String.IsNullOrEmpty(Name)) xMaster.Add(new XAttribute("region-name", Name));
            if (!String.IsNullOrEmpty(BackgroundRepeat)) xMaster.Add(new XAttribute("background-repeat", BackgroundRepeat));
            if (!String.IsNullOrEmpty(BackgroundImage)) xMaster.Add(new XAttribute("background-image", "url(" + BackgroundImage + ")"));
            if (ColumnCount > 0) xMaster.Add(new XAttribute("column-count", ColumnCount));
            if (!String.IsNullOrEmpty(ColumnGap)) xMaster.Add(new XAttribute("column-gap", ColumnGap));
            if (!String.IsNullOrEmpty(Extent)) xMaster.Add(new XAttribute("extent", Extent));
            if (!String.IsNullOrEmpty(Margin)) xMaster.Add(new XAttribute("margin", Margin));
            if (!String.IsNullOrEmpty(MarginTop)) xMaster.Add(new XAttribute("margin-top", MarginTop));
            if (!String.IsNullOrEmpty(MarginRight)) xMaster.Add(new XAttribute("margin-right", MarginRight));
            if (!String.IsNullOrEmpty(MarginBottom)) xMaster.Add(new XAttribute("margin-bottom", MarginBottom));
            if (!String.IsNullOrEmpty(MarginLeft)) xMaster.Add(new XAttribute("margin-left", MarginLeft));
            return xMaster;
        }

    }

}