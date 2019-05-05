using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Regions {
    
    /// <summary>
    /// A viewport that is located on the "before" side of fo:region-body region.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_region-before</cref>
    /// </see>
    public class FoRegionBefore : FoRegion {

        /// <inheritdoc/>
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("region-before");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

    }

}