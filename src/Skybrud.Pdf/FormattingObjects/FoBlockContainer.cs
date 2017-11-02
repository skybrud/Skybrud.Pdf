using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoBlockContainer : FoContainer {

        public FoBlockContainer() {
            // Expose default constructor
        }

        public FoBlockContainer(IEnumerable<FoBaseElement> elements) {
            AddRange(elements);
        }

        public FoBlockContainer(params FoBaseElement[] elements) {
            AddRange(elements);
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlockContainer = new XElement(FoDocument.Namespace + "block-container");
            AddAttributes(xBlockContainer);
            AddChildren(xBlockContainer, Elements, options);
            return xBlockContainer;
        }

    }

}