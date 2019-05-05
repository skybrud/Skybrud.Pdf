using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Pages {

    /// <summary>
    /// Represents a collection of <see cref="FoPageSequence"/> elements.
    /// </summary>
    public class FoPageSequenceCollection : FoCollection<FoPageSequence> {

        #region Constructors

        public FoPageSequenceCollection() { }

        public FoPageSequenceCollection(IEnumerable<FoPageSequence> items) : base(items) { }

        #endregion

    }

}