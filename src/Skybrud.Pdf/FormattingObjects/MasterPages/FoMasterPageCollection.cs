using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.MasterPages {

    /// <summary>
    /// Represents a collection of <see cref="FoMasterPage"/> elements.
    /// </summary>
    public class FoMasterPageCollection : FoCollection<FoMasterPage> {

        #region Constructors

        public FoMasterPageCollection() { }

        public FoMasterPageCollection(IEnumerable<FoMasterPage> items) : base(items) { }

        #endregion

    }

}