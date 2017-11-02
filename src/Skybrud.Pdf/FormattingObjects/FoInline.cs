using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoInline : FoContainer {

        #region Constructor(s)

        public FoInline() {
            // Expose default constructor
        }

        public FoInline(string text) {
            Add(new FoText(text));
        }

        public FoInline(IEnumerable<FoBaseElement> elements) {
            AddRange(elements);
        }

        public FoInline(params FoBaseElement[] elements) {
            AddRange(elements);
        }

        #endregion

        public override XElement ToXElement() {
            XElement xBlock = new XElement(FoDocument.Namespace + "inline");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements);
            return xBlock;
        }

    }

}