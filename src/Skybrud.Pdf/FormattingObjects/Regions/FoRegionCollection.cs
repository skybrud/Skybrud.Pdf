using System.Collections.Generic;

namespace Skybrud.Pdf.FormattingObjects.Regions {

    /// <summary>
    /// Represents a collection of <see cref="FoRegion"/> elements.
    /// </summary>
    public class FoRegionCollection : FoCollection<FoRegion> {

        #region Constructors

        public FoRegionCollection() { }

        public FoRegionCollection(IEnumerable<FoRegion> items) : base(items) { }

        #endregion

    }

}