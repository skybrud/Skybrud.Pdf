using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoMagic : FoElement {

        protected XElement X { get; private set; }

        public FoMagic(XElement x) {
            X = x;
        }
        
        public override XElement ToXElement() {
            return X;
        }
    
    }

}