using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoBasicLink : FoBlock {

        #region Properties
        
        public string InternalDestination { get; set; }
        public string ExternalDestination { get; set; }

        #endregion

        #region Constructor(s)

        public FoBasicLink() {
            // Expose default constructor
        }

        public FoBasicLink(string text) {
            Add(new FoText(text));
        }

        public FoBasicLink(IEnumerable<FoBaseElement> elements) {
            AddRange(elements);
        }

        public FoBasicLink(params FoBaseElement[] elements) {
            AddRange(elements);
        }

        #endregion

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "basic-link");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            if (!String.IsNullOrEmpty(InternalDestination)) {
                xBlock.Add(new XAttribute("internal-destination", InternalDestination));
            } else if (!String.IsNullOrEmpty(ExternalDestination)) {
                xBlock.Add(new XAttribute("external-destination", "url('" + ExternalDestination + "')"));
            }
            return xBlock;
        }

    }

}
