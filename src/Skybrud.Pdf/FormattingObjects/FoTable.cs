using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoTable : FoElement {

        private List<FoTableRow> _rows = new List<FoTableRow>();

        protected List<FoTableColumn> Columns = new List<FoTableColumn>();

        public string Margin { get; set; }
        public string MarginTop { get; set; }
        public string MarginRight { get; set; }
        public string MarginBottom { get; set; }
        public string MarginLeft { get; set; }

        public FoTableRow[] Rows {
            get { return _rows.ToArray(); }
            set { _rows = (value ?? new FoTableRow[0]).ToList(); }
        }

        public FoTable() {}

        public FoTable(params FoTableRow[] rows) {
            AddRows(rows);
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xTable = new XElement(FoDocument.Namespace + "table");
            if (!String.IsNullOrEmpty(Margin)) xTable.Add(new XAttribute("margin", Margin));
            if (!String.IsNullOrEmpty(MarginTop)) xTable.Add(new XAttribute("margin-top", MarginTop));
            if (!String.IsNullOrEmpty(MarginRight)) xTable.Add(new XAttribute("margin-right", MarginRight));
            if (!String.IsNullOrEmpty(MarginBottom)) xTable.Add(new XAttribute("margin-bottom", MarginBottom));
            if (!String.IsNullOrEmpty(MarginLeft)) xTable.Add(new XAttribute("margin-left", MarginLeft));
            XElement xBody = new XElement(FoDocument.Namespace + "table-body");
            foreach (FoTableColumn column in Columns) {
                xTable.Add(column.ToXElement());
            }
            foreach (FoTableRow row in _rows) {
                xBody.Add(row.ToXElement());
            }
            xTable.Add(xBody);
            return xTable;
        }

        public FoTableColumn AddColumn(FoTableColumn column) {
            Columns.Add(column);
            return column;
        }

        public FoTableRow AddRow(FoTableRow row) {
            _rows.Add(row);
            return row;
        }

        public FoTable AddRows(IEnumerable<FoTableRow> rows) {
            foreach (var row in rows) _rows.Add(row);
            return this;
        }

        public FoTable AddRows(params FoTableRow[] rows) {
            foreach (var row in rows) _rows.Add(row);
            return this;
        }

        public FoTableRow CreateRow() {
            return AddRow(new FoTableRow());
        }

    }

}