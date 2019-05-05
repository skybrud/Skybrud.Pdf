using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Tables {

    /// <summary>
    /// Represents a collection of <see cref="FoTableColumn"/> elements.
    /// </summary>
    public class FoTableColumnCollection : FoCollection<FoTableColumn> {

        #region Constructors

        public FoTableColumnCollection() { }

        public FoTableColumnCollection(IEnumerable<FoTableColumn> items) : base(items) { }

        #endregion

    }

}