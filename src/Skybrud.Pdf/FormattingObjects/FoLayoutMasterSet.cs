using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoLayoutMasterSet : FoElement {

        private List<FoMasterPage> _masterPages = new List<FoMasterPage>();

        public FoMasterPage[] MasterPages {
            get { return _masterPages.ToArray(); }
        }

        public void AddMasterPage(FoMasterPage masterPage) {
            _masterPages.Add(masterPage);
        }

        public override XElement ToXElement() {
            return new XElement(
                FoDocument.Namespace + "layout-master-set",
                from master in _masterPages select master.ToXElement()
            );
        }

    }

}
