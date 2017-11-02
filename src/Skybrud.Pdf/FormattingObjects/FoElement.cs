using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoElement : FoBaseElement {

        public XElement ToXElement() {
            return ToXElement(default(FoRenderOptions));
        }

        public abstract XElement ToXElement(FoRenderOptions options);

        public override string ToString() {
            return ToXElement().ToString();
        }

        public string ToString(FoRenderOptions options) {
            return ToXElement(options).ToString(options?.SaveOptions ?? SaveOptions.None);
        }

    }

}