using System;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoPageNumberCitationLast : FoContainer {

        #region Properties

        public string PageCitationStrategy { get; set; }

        public string ReferenceId { get; set; }

        #endregion

        #region Constructors

        public FoPageNumberCitationLast() { }

        public FoPageNumberCitationLast(string pageCitationStrategy, string referenceId) {
            PageCitationStrategy = pageCitationStrategy;
            ReferenceId = referenceId;
        }

        #endregion

        public override XElement ToXElement() {
            XElement xBlock = new XElement(FoDocument.Namespace + "page-number-citation-last");
            if (!String.IsNullOrWhiteSpace(PageCitationStrategy)) xBlock.Add(new XAttribute("page-citation-strategy", "all"));
            if (!String.IsNullOrWhiteSpace(ReferenceId)) xBlock.Add(new XAttribute("ref-id", "Master"));
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements);
            return xBlock;
        }

    }

}