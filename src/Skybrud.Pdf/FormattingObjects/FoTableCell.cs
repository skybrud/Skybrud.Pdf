using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoTableCell : FoContainer {

        public int Colspan { get; set; }
        public int Rowspan { get; set; }

        public FoTableCell() {
            // Expose default constructor
        }

        public FoTableCell(IEnumerable<FoBaseElement> elements) {
            AddRange(elements);
        }

        public FoTableCell(params FoBaseElement[] elements) {
            AddRange(elements);
        }

        public override XElement ToXElement() {
            XElement xCell = new XElement(FoDocument.Namespace + "table-cell");
            AddAttributes(xCell);
            AddChildren(xCell, Elements);
            return xCell;
        }

        protected override IDictionary<string, string> RenderAttributes() {
            var dictionary = base.RenderAttributes();
            if (Colspan > 0) dictionary.Add("number-columns-spanned", Colspan + "");
            if (Rowspan > 0) dictionary.Add("number-rows-spanned", Rowspan + "");
            return dictionary;
        }

    }

}