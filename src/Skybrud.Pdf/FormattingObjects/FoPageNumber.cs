using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoPageNumber : FoContainer {

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "page-number");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            return xBlock;
        }

    }

}