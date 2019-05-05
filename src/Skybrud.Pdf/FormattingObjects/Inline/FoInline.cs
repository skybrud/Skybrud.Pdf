using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Inline {
    
    /// <summary>
    /// Formats a portion of text with a background or enclosing it in a border.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_inline</cref>
    /// </see>
    public class FoInline : FoContainer<FoNode> {

        #region Constructors

        public FoInline() { }

        public FoInline(string text) {
            Add(new FoText(text));
        }

        public FoInline(IEnumerable<FoNode> children) {
            AddRange(children);
        }

        public FoInline(params FoNode[] children) {
            AddRange(children);
        }

        #endregion

        #region Member methods

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("inline");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion


    }

}