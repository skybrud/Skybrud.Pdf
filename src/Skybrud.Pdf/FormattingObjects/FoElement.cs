using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoElement : FoBaseElement {

        public abstract XElement ToXElement();

        public override string ToString() {
            return ToXElement().ToString();
        }

        public string ToString(SaveOptions options) {
            return ToXElement().ToString(options);
        }

    }

}