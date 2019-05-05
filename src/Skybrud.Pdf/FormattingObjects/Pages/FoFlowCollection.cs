using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Pages {

    /// <summary>
    /// Represents a collection of <see cref="FoFlow"/> elements.
    /// </summary>
    public class FoFlowCollection : FoCollection<FoFlow> {

        #region Constructors

        public FoFlowCollection() { }

        public FoFlowCollection(IEnumerable<FoFlow> items) : base(items) { }

        #endregion

    }

}