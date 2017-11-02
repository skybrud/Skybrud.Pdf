using System;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoTableColumn : FoBaseElement {

        public string Width;

        public FoTableColumn() {
            // Expose default constructor
        }

        public FoTableColumn(string width) {
            Width = width;
        }

        public XElement ToXElement() {
            XElement xColumn = new XElement(FoDocument.Namespace + "table-column");
            if (!String.IsNullOrEmpty(Width)) xColumn.Add(new XAttribute("column-width", Width));
            return xColumn;
        }

    }

}