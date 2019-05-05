using System.Xml.Linq;
using Skybrud.Essentials.Common;

namespace Skybrud.Pdf.FormattingObjects.Lists {
    
    /// <summary>
    /// The label and the body of an item in a list.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_list-item</cref>
    /// </see>
    public class FoListItem : FoBlock {

        #region Properties

        /// <summary>
        /// The label of a list-item; typically used to either enumerate, identify, or adorn the list-item's body.
        /// </summary>
        public FoListItemLabel Label { get; set; }

        /// <summary>
        /// The body of a list-item.
        /// </summary>
        public FoListItemBody Body { get; set; }

        #endregion

        #region Member methods

        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            if (Label == null) throw new PropertyNotSetException(nameof(Label));
            if (Body == null) throw new PropertyNotSetException(nameof(Body));
            element.Add(Label.ToXElement(options));
            element.Add(Body.ToXElement(options));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xListItem = Fo("list-item");
            RenderAttributes(xListItem, options);
            RenderChildren(xListItem, options);
            return xListItem;
        }

        #endregion

    }

}