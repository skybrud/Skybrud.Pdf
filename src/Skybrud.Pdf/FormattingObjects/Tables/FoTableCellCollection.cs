using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Tables {

    /// <summary>
    /// Represents a collection of <see cref="FoTableCell"/> elements.
    /// </summary>
    public class FoTableCellCollection : FoCollection<FoTableCell> {

        #region Constructors

        public FoTableCellCollection() { }

        public FoTableCellCollection(IEnumerable<FoTableCell> items) : base(items) { }

        #endregion

    }

}