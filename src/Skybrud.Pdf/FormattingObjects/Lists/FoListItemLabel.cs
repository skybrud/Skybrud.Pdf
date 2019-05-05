using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Lists {

    /// <summary>
    /// The label of a list-item; typically used to either enumerate, identify, or adorn the list-item's body.
    /// </summary>
    public class FoListItemLabel : FoBlock {

        #region Properties

        public string StartIndent { get; set; }

        public string EndIndent { get; set; }

        #endregion

        #region Constructors

        public FoListItemLabel() { }

        public FoListItemLabel(string text) : base(text) { }

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (StartIndent.HasValue()) element.Add(new XAttribute("start-indent", StartIndent));
            if (EndIndent.HasValue()) element.Add(new XAttribute("end-indent", EndIndent));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xLabel = Fo("list-item-label");
            RenderAttributes(xLabel, options);
            RenderChildren(xLabel, options);
            return xLabel;
        }

        #endregion

    }

}