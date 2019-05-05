using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.MasterPages {
    
    /// <summary>
    /// A wrapper around all masters used in the document.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_layout-master-set</cref>
    /// </see>
    public class FoLayoutMasterSet : FoElement {

        #region Properties

        public FoMasterPageCollection MasterPages { get; } = new FoMasterPageCollection();

        #endregion

        #region Constructors

        public FoLayoutMasterSet() { }

        public FoLayoutMasterSet(params FoMasterPage[] masterPages) {
            MasterPages.AddRange(masterPages);
        }

        #endregion

        #region Member methods

        public void Add(FoMasterPage masterPage) {
            MasterPages.Add(masterPage);
        }

        public void AddRange(IEnumerable<FoMasterPage> masterPages) {
            MasterPages.AddRange(masterPages);
        }
        
        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            base.RenderChildren(element, options);
            foreach (var masterPage in MasterPages) element.Add(masterPage.ToXElement(options));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("layout-master-set");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}