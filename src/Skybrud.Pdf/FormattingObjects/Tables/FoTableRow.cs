using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Tables {
    
    /// <summary>
    /// Groups table-cells into rows.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_table-row</cref>
    /// </see>
    public class FoTableRow : FoElement {

        #region Properties

        /// <summary>
        /// Imposes keep-together conditions on formatting objects.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#keep-together</cref>
        /// </see>
        public string KeepTogether { get; set; }

        /// <summary>
        /// Imposes keep-together conditions on formatting objects.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#keep-together</cref>
        /// </see>
        public string KeepTogetherWithinColumn { get; set; }

        public FoTableCellCollection Cells { get; } = new FoTableCellCollection();

        #endregion

        #region Constructors

        public FoTableRow() { }

        public FoTableRow(params FoTableCell[] cells) {
            Cells.AddRange(cells);
        }

        #endregion

        #region Member methods

        public FoTableCell AddCell(FoTableCell cell) {
            Cells.Add(cell);
            return cell;
        }

        public FoTableRow AddCells(IEnumerable<FoTableCell> cells) {
            Cells.AddRange(cells);
            return this;
        }

        public FoTableRow AddCells(params FoTableCell[] cells) {
            Cells.AddRange(cells);
            return this;
        }

        public FoTableCell CreateCell() {
            return AddCell(new FoTableCell());
        }     

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (KeepTogetherWithinColumn.HasValue()) element.Add(new XAttribute("keep-together", KeepTogetherWithinColumn));
            if (KeepTogetherWithinColumn.HasValue()) element.Add(new XAttribute("keep-together.within-column", KeepTogetherWithinColumn));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("table-row");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}