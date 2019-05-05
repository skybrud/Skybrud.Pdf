using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Lists {
    
    /// <summary>
    /// A list.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_list-block</cref>
    /// </see>
    public class FoListBlock : FoContainer<FoListItem> {

        #region Constructors

        public FoListBlock() { }

        public FoListBlock(params FoListItem[] items) {
            AddRange(items);
        }

        #endregion

        #region Member methods

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xListBlock = Fo("list-block");
            RenderAttributes(xListBlock, options);
            RenderChildren(xListBlock, options);
            return xListBlock;
        }

        #endregion

    }

}