using System.Xml.Linq;
using Skybrud.Pdf.FormattingObjects.Inline;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// The current page-number.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_page-number</cref>
    /// </see>
    public class FoPageNumber : FoInline {

        #region Member methods

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("page-number");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

    }

}