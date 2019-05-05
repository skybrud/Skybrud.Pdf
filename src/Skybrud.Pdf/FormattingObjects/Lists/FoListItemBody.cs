using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Lists {
    /// <summary>
    /// The body of a list-item.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_list-item-body</cref>
    /// </see>
    public class FoListItemBody : FoBlock {

        #region Properties

        public string StartIndent { get; set; }

        public string EndIndent { get; set; }

        #endregion

        #region Constructors

        public FoListItemBody() { }

        public FoListItemBody(string text) : base(text) { }

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (StartIndent.HasValue()) element.Add(new XAttribute("start-indent", StartIndent));
            if (EndIndent.HasValue()) element.Add(new XAttribute("end-indent", EndIndent));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("list-item-body");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

    }

}