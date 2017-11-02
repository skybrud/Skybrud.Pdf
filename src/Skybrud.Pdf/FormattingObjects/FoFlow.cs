using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoFlow : FoPageElement {

        public string Name { get; set; }
        
        public FoFlow(string name) {
            Name = name;
        }

        public FoFlow(string name, IEnumerable<FoBaseElement> elements) {
            Name = name;
            AddRange(elements);
        }

        public FoFlow(string name, params FoBaseElement[] elements) {
            Name = name;
            AddRange(elements);
        }

        public override XElement ToXElement() {
            return AddChildren(new XElement(
                FoDocument.Namespace + "flow",
                new XAttribute("flow-name", Name)
            ), Elements);
        }

    }

}