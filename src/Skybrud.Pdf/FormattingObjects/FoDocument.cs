using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoDocument {

        private FoLayoutMasterSet _layoutMasterSet = new FoLayoutMasterSet();
        private List<FoPage> _pages = new List<FoPage>();

        public static XNamespace Namespace {
            get { return "http://www.w3.org/1999/XSL/Format"; }
        }

        public static XNamespace NamespaceIbex {
            get { return "http://www.xmlpdf.com/2003/ibex/Format"; }
        }

        public string Title;
        public string Author;
        public string Subject;
        public string[] Keywords;
        public string Creator;

        public FoLayoutMasterSet LayoutMasterSet {
            get { return _layoutMasterSet; }
        }

        public void AddPage(FoPage page) {
            _pages.Add(page);
        }

        public XElement ToXElement() {
            return ToXElement(default(FoRenderOptions));
        }

        public XElement ToXElement(FoRenderOptions options) {

            XElement element = new XElement(Namespace + "root",
                new XAttribute(XNamespace.Xmlns + "fo", Namespace)
                //new XAttribute(XNamespace.Xmlns + "ibex", NamespaceIbex)
            );

            XElement xProperties = new XElement(NamespaceIbex + "properties");

            if (!String.IsNullOrEmpty(Title)) xProperties.Add(new XAttribute("title", Title));
            if (!String.IsNullOrEmpty(Author)) xProperties.Add(new XAttribute("author", Author));
            if (!String.IsNullOrEmpty(Subject)) xProperties.Add(new XAttribute("subject", Subject));
            if (Keywords != null && Keywords.Length > 0) xProperties.Add(new XAttribute("title", String.Join(",", Keywords)));
            if (!String.IsNullOrEmpty(Creator)) xProperties.Add(new XAttribute("creator", Creator));

            element.Add(LayoutMasterSet.ToXElement(options));

            foreach (var page in _pages) {
                element.Add(page.ToXElement(options));
            }

            return element;

        }
        public XDocument ToXDocument() {
            return ToXDocument(default(FoRenderOptions));
        }

        public XDocument ToXDocument(FoRenderOptions options) {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                ToXElement(options)
            );
        }
        
        public XmlDocument ToXmlDocument() {
            return ToXmlDocument(default(FoRenderOptions));
        }
        
        public XmlDocument ToXmlDocument(FoRenderOptions options) {
            XmlDocument xmlDocument = new XmlDocument();
            using (XmlReader xmlReader = ToXDocument(options).CreateReader()) {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public override string ToString() {
            return ToXElement().ToString();
        }

        public string ToString(SaveOptions options) {
            return ToXElement().ToString(options);
        }

        public FoPage CreatePage(string masterPageName) {
            return CreatePage(masterPageName, null);
        }

        public FoPage CreatePage(string masterPageName, string id) {
            FoPage page = new FoPage(masterPageName) { Id = id };
            AddPage(page);
            return page;
        }
    
    }

}