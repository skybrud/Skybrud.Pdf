using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Regions {

    public abstract class FoRegion : FoElement {

        #region Properties

        /// <summary>
        /// Identifies a region within a simple-page-master.
        /// </summary>
        /// <see cref="http://www.datypic.com/sc/fo11/a-region-name-1.html"/>
        public string RegionName { get; set; }

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

        #endregion

        #region Member methods
        
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            if (RegionName.HasValue()) element.Add(new XAttribute("region-name", RegionName));
            if (BackgroundRepeat.HasValue()) element.Add(new XAttribute("background-repeat", BackgroundRepeat));
            if (BackgroundImage.HasValue()) element.Add(new XAttribute("background-image", "url(" + BackgroundImage + ")"));
            if (ColumnCount > 0) element.Add(new XAttribute("column-count", ColumnCount));
            if (ColumnGap.HasValue()) element.Add(new XAttribute("column-gap", ColumnGap));
            if (Extent.HasValue()) element.Add(new XAttribute("extent", Extent));
            if (Margin.HasValue()) element.Add(new XAttribute("margin", Margin));
            if (MarginTop.HasValue()) element.Add(new XAttribute("margin-top", MarginTop));
            if (MarginRight.HasValue()) element.Add(new XAttribute("margin-right", MarginRight));
            if (MarginBottom.HasValue()) element.Add(new XAttribute("margin-bottom", MarginBottom));
            if (MarginLeft.HasValue()) element.Add(new XAttribute("margin-left", MarginLeft));
        }

        #endregion

    }

}