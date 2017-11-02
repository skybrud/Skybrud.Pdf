using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoPage : FoElement {

        private List<FoStaticContent> _static = new List<FoStaticContent>();
        private List<FoFlow> _flows = new List<FoFlow>();

        #region Properties

        public string MasterPage { get; private set; }

        public string Id { get; set; }

        public FoFlow[] Flows {
            get { return _flows.ToArray(); }
        }

        public FoStaticContent[] StaticContent {
            get { return _static.ToArray(); }
        }

        #endregion

        public FoPage(string name, params FoFlow[] flows) {
            MasterPage = name;
            foreach (var flow in flows) AddFlow(flow);
        }

        public void AddStaticContent(FoStaticContent staticContent) {
            if (staticContent != null) _static.Add(staticContent);
        }

        public void AddFlow(FoFlow flow) {
            if (flow != null) _flows.Add(flow);
        }

        public override XElement ToXElement() {

            XElement xPageSequence = new XElement(
                FoDocument.Namespace + "page-sequence",
                new XAttribute("master-reference", MasterPage ?? "")
            );

            if (!String.IsNullOrWhiteSpace(Id)) {
                xPageSequence.Add(new XAttribute("id", MasterPage ?? ""));
            }

            foreach (FoStaticContent foStaticContent in _static) {
                xPageSequence.Add(foStaticContent.ToXElement());
            }

            foreach (FoFlow foFlow in _flows) {
                xPageSequence.Add(foFlow.ToXElement());
            }

            return xPageSequence;

        }
    
    }

}