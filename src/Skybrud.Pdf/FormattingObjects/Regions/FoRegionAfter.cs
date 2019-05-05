using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Regions {
    
    /// <summary>
    /// A viewport that is located on the "after" side of fo:region-body region.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_region-after</cref>
    /// </see>
    public class FoRegionAfter : FoRegion {

        /// <inheritdoc/>
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("region-after");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

    }

}