using System;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoExternalGraphic : FoElement {

        public FoExternalGraphic() {
            // expose default constructor
        }

        public FoExternalGraphic(string url) {
            Url = url;
        }

        public string Url;

        public string Width;
        public string Height;
        public string ContentWidth;
        public string ContentHeight;
        public string Scaling;

        public override XElement ToXElement() {
            XElement xGraphic = new XElement(FoDocument.Namespace + "external-graphic", new XAttribute("src", "url(" + Url + ")"));
            if (!String.IsNullOrEmpty(Width)) xGraphic.Add(new XAttribute("width", Width));
            if (!String.IsNullOrEmpty(Height)) xGraphic.Add(new XAttribute("height", Height));
            if (!String.IsNullOrEmpty(ContentWidth)) xGraphic.Add(new XAttribute("content-width", ContentWidth));
            if (!String.IsNullOrEmpty(ContentHeight)) xGraphic.Add(new XAttribute("content-height", ContentHeight));
            if (!String.IsNullOrEmpty(Scaling)) xGraphic.Add(new XAttribute("scaling", Scaling));
            return xGraphic;
        }

    }

}