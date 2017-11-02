using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoMasterPage : FoElement {

        private List<FoPageRegion> _regions = new List<FoPageRegion>();

        public string Name { get; private set; }
        public string PageWidth { get; set; }
        public string PageHeight { get; set; }
        public string Margin { get; set; }
        public string MarginTop { get; set; }
        public string MarginRight { get; set; }
        public string MarginBottom { get; set; }
        public string MarginLeft { get; set; }

        public FoPageRegion[] Regions {
            get { return _regions.ToArray(); }
        }

        public FoMasterPage(string name, string pageWidth, string pageHeight) {
            Name = name;
            PageWidth = pageWidth;
            PageHeight = pageHeight;
        }

        public void AddRegion(FoPageRegion region) {
            if (region != null) _regions.Add(region);
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xMaster = new XElement(
                FoDocument.Namespace + "simple-page-master",
                new XAttribute("master-name", Name ?? ""),
                new XAttribute("page-width", PageWidth),
                new XAttribute("page-height", PageHeight)
            );
            if (!String.IsNullOrEmpty(Margin)) xMaster.Add(new XAttribute("margin", Margin));
            if (!String.IsNullOrEmpty(MarginTop)) xMaster.Add(new XAttribute("margin-top", MarginTop));
            if (!String.IsNullOrEmpty(MarginRight)) xMaster.Add(new XAttribute("margin-right", MarginRight));
            if (!String.IsNullOrEmpty(MarginBottom)) xMaster.Add(new XAttribute("margin-bottom", MarginBottom));
            if (!String.IsNullOrEmpty(MarginLeft)) xMaster.Add(new XAttribute("margin-left", MarginLeft));
            foreach (var region in _regions) xMaster.Add(region.ToXElement());
            return xMaster;
        }

    }

}