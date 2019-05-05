using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Tables {
    
    /// <summary>
    /// Characteristics applicable to table cells that have the same column and span.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_table-column</cref>
    /// </see>
    public class FoTableColumn : FoElement {

        #region Properties

        /// <summary>
        /// Specifies the column-number of the table cells that may use properties from this fo:table-column formatting
        /// object by using the from-table-column() function. The initial value is 1 plus the column-number of the
        /// previous table-column, if there is a previous table-column, and otherwise 1.
        /// </summary>
        /// <see>
        ///     <cref>http://www.datypic.com/sc/fo11/a-column-number-1.html</cref>
        /// </see>
        public int ColumnNumber { get; set; }

        /// <summary>
        /// The width of the column whose value is given by the "column-number" property. This property, if present, is
        /// ignored if the "number-columns-spanned" property is greater than 1. The "column-width" property must be
        /// specified for every column, unless the automatic table layout is used.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#column-number</cref>
        /// </see>
        public string ColumnWidth { get; set; }

        #endregion

        #region Constructors

        public FoTableColumn() { }

        public FoTableColumn(string columnWidth) {
            ColumnWidth = columnWidth;
        }

        #endregion

        #region Member methods
        
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (ColumnNumber > 0) element.Add(new XAttribute("column-number", ColumnNumber));
            if (ColumnWidth.HasValue()) element.Add(new XAttribute("column-width", ColumnWidth));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("table-column");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}