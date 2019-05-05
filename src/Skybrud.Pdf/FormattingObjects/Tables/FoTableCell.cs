using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Tables {
    
    /// <summary>
    /// A table cell.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_table-cell</cref>
    /// </see>
    public class FoTableCell : FoContainer<FoElement> {

        #region Properties

        /// <summary>
        /// Alias <see cref="NumberColumnsSpanned"/>.
        /// </summary>
        public int Colspan => NumberColumnsSpanned;

        /// <summary>
        /// The number of columns which this cell spans in the column-progression-direction starting with the current column.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#number-columns-spanned</cref>
        /// </see>
        public int NumberColumnsSpanned { get; set; }

        /// <summary>
        /// Alias of <see cref="NumberRowsSpanned"/>.
        /// </summary>
        public int Rowspan => NumberRowsSpanned;

        /// <summary>
        /// The number of rows which this cell spans in the row-progression-direction starting with the current row.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#number-rows-spanned</cref>
        /// </see>
        public int NumberRowsSpanned { get; set; }

        #endregion

        #region Constructors

        public FoTableCell() { }

        public FoTableCell(IEnumerable<FoElement> children) {
            AddRange(children);
        }

        public FoTableCell(params FoElement[] children) {
            AddRange(children);
        }

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (NumberColumnsSpanned > 0) element.Add(new XAttribute("number-columns-spanned", NumberColumnsSpanned));
            if (NumberRowsSpanned > 0) element.Add(new XAttribute("number-rows-spanned", NumberRowsSpanned));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("table-cell");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}