using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// Represents a collection of <see cref="FoStaticContent"/> elements.
    /// </summary>
    public class FoStaticContentCollection : FoCollection<FoStaticContent> {

        #region Constructors

        public FoStaticContentCollection() { }

        public FoStaticContentCollection(IEnumerable<FoStaticContent> items) : base(items) { }

        #endregion

    }

}