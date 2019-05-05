using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Regions {
    
    /// <summary>
    /// A viewport/reference pair that is located in the "center" of the fo:simple-page-master.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#region-name</cref>
    /// </see>
    public class FoRegionBody : FoRegion {

        /// <inheritdoc/>
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("region-body");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

    }

}