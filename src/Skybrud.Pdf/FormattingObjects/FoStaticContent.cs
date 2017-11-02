using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoStaticContent : FoContainer {

        public string Name { get; set; }
        
        public FoStaticContent(string name) {
            Name = name;
        }

        public FoStaticContent(string name, IEnumerable<FoBaseElement> elements) {
            Name = name;
            AddRange(elements);
        }

        public FoStaticContent(string name, params FoBaseElement[] elements) {
            Name = name;
            AddRange(elements);
        }

        public override XElement ToXElement() {
            return AddChildren(new XElement(
                FoDocument.Namespace + "static-content",
                new XAttribute("flow-name", Name)
            ), Elements);
        }

    }

}
