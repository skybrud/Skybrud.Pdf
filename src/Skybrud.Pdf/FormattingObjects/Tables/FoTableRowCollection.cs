using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Tables {

    /// <summary>
    /// Represents a collection of <see cref="FoTableRow"/> elements.
    /// </summary>
    public class FoTableRowCollection : FoCollection<FoTableRow> {

        #region Constructors

        public FoTableRowCollection() { }

        public FoTableRowCollection(IEnumerable<FoTableRow> items) : base(items) { }

        #endregion

    }

}