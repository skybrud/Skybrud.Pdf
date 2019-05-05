using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Tables {

    public class FoTable : FoElement {

        #region Properties

        public string Margin { get; set; }

        public string MarginTop { get; set; }

        public string MarginRight { get; set; }

        public string MarginBottom { get; set; }

        public string MarginLeft { get; set; }

        public FoTableColumnCollection Columns { get; } = new FoTableColumnCollection();

        public FoTableBody Body { get; } = new FoTableBody();

        #endregion

        #region Constructors

        public FoTable() { }

        public FoTable(params FoTableRow[] rows) {
            Body.Rows.AddRange(rows);
        }

        #endregion

        #region Member methods

        public FoTableColumn AddColumn(FoTableColumn column) {
            Columns.Add(column);
            return column;
        }

        public FoTableRow AddRow(FoTableRow row) {
            Body.Rows.Add(row);
            return row;
        }

        public FoTable AddRows(IEnumerable<FoTableRow> rows) {
            foreach (FoTableRow row in rows) Body.Rows.Add(row);
            return this;
        }

        public FoTable AddRows(params FoTableRow[] rows) {
            foreach (FoTableRow row in rows) Body.Rows.Add(row);
            return this;
        }

        public FoTableRow CreateRow() {
            return AddRow(new FoTableRow());
        }

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (Margin.HasValue()) element.Add(new XAttribute("margin", Margin));
            if (MarginTop.HasValue()) element.Add(new XAttribute("margin-top", MarginTop));
            if (MarginRight.HasValue()) element.Add(new XAttribute("margin-right", MarginRight));
            if (MarginBottom.HasValue()) element.Add(new XAttribute("margin-bottom", MarginBottom));
            if (MarginLeft.HasValue()) element.Add(new XAttribute("margin-left", MarginLeft));
        }

        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            base.RenderChildren(element, options);
            foreach (FoTableColumn column in Columns) element.Add(column.ToXElement(options));
            element.Add(Body.ToXElement(options));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("table");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}