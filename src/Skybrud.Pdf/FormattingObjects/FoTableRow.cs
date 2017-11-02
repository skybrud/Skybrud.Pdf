using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoTableRow : FoElement {

        private List<FoTableCell> _cells = new List<FoTableCell>();

        #region Properties

        public FoTableCell[] Cells {
            get { return _cells.ToArray(); }
            set { _cells = (value ?? new FoTableCell[0]).ToList(); }
        }
        
        public string KeepTogether { get; set; }

        public string KeepTogetherWithinColumn { get; set; }

        #endregion

        #region Constructors

        public FoTableRow() { }

        public FoTableRow(params FoTableCell[] cells) {
            foreach (var cell in cells) {
                _cells.Add(cell);
            }
        }

        #endregion

        #region Member methods

        public override XElement ToXElement() {
            XElement xRow = new XElement(FoDocument.Namespace + "table-row");
            AddAttributes(xRow);
            foreach (FoTableCell cell in Cells) {
                xRow.Add(cell.ToXElement());
            }
            return xRow;
        }

        public FoTableCell AddCell(FoTableCell cell) {
            _cells.Add(cell);
            return cell;
        }

        public FoTableRow AddCells(IEnumerable<FoTableCell> cells) {
            foreach (var cell in cells) _cells.Add(cell);
            return this;
        }

        public FoTableRow AddCells(params FoTableCell[] cells) {
            foreach (var cell in cells) _cells.Add(cell);
            return this;
        }

        public FoTableCell CreateCell() {
            return AddCell(new FoTableCell());
        }

        protected virtual IDictionary<string, string> RenderAttributes() {
            var dictionary = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(KeepTogether)) dictionary.Add("keep-together", KeepTogetherWithinColumn);
            if (!String.IsNullOrEmpty(KeepTogetherWithinColumn)) dictionary.Add("keep-together.within-column", KeepTogetherWithinColumn);
            return dictionary;
        }

        protected void AddAttributes(XElement e) {
            foreach (var pair in RenderAttributes()) {
                e.Add(new XAttribute(pair.Key, pair.Value));
            }
        }

        #endregion

    }

}