using System.Xml.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Pdf.FormattingObjects.Regions;

namespace Skybrud.Pdf.FormattingObjects.MasterPages {
    
    /// <summary>
    /// Used in the generation of pages and specifies the geometry of the page. The page is subdivided into regions.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_simple-page-master</cref>
    /// </see>
    public class FoSimpleMasterPage : FoMasterPage {

        #region Properties

        /// <summary>
        /// Names identify masters, may not be empty and must be unique.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#master-name</cref>
        /// </see>
        public string MasterName { get; set; }

        /// <summary>
        /// The width of the page.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#page-width</cref>
        /// </see>
        public string PageWidth { get; set; }

        /// <summary>
        /// The height of the page.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#page-height</cref>
        /// </see>
        public string PageHeight { get; set; }

        public string Margin { get; set; }

        public string MarginTop { get; set; }

        public string MarginRight { get; set; }

        public string MarginBottom { get; set; }

        public string MarginLeft { get; set; }

        public FoRegionCollection Regions { get; } = new FoRegionCollection();

        #endregion

        #region Constructors

        public FoSimpleMasterPage(string masterName, string pageWidth, string pageHeight) {
            MasterName = masterName;
            PageWidth = pageWidth;
            PageHeight = pageHeight;
        }

        #endregion

        #region Member methods
        
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {

            base.RenderAttributes(element, options);

            if (MasterName.IsNullOrWhiteSpace()) throw new PropertyNotSetException(nameof(MasterName));
            element.Add(new XAttribute("master-name", MasterName));

            if (PageWidth.HasValue()) element.Add(new XAttribute("page-width", PageWidth));
            if (PageHeight.HasValue()) element.Add(new XAttribute("page-height", PageHeight));
            if (Margin.HasValue()) element.Add(new XAttribute("margin", Margin));
            if (MarginTop.HasValue()) element.Add(new XAttribute("margin-top", MarginTop));
            if (MarginRight.HasValue()) element.Add(new XAttribute("margin-right", MarginRight));
            if (MarginBottom.HasValue()) element.Add(new XAttribute("margin-bottom", MarginBottom));
            if (MarginLeft.HasValue()) element.Add(new XAttribute("margin-left", MarginLeft));

        }
        
        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            base.RenderChildren(element, options);
            foreach (FoRegion region in Regions) element.Add(region.ToXElement(options));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("simple-page-master");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}