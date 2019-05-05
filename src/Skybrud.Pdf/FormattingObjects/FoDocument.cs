using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Pdf.FormattingObjects.Ibex;
using Skybrud.Pdf.FormattingObjects.MasterPages;
using Skybrud.Pdf.FormattingObjects.Pages;

namespace Skybrud.Pdf.FormattingObjects {
    
    public class FoDocument : FoElement {

        #region Properties

        public IbexProperties Properties { get; set; }
        
        /// <summary>
        /// A wrapper around all masters used in the document.
        /// </summary>
        public FoLayoutMasterSet LayoutMasterSet { get; set; } = new FoLayoutMasterSet();

        /// <summary>
        /// Specifies how to create a (sub-)sequence of pages within a document; for example, a chapter of a report.
        /// </summary>
        public FoPageSequenceCollection PageSequences { get; } = new FoPageSequenceCollection();

        #endregion

        #region Member methods

        public void AddPageSequence(FoPageSequence pageSequence) {
            PageSequences.Add(pageSequence);
        }

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            element.Add(new XAttribute(XNamespace.Xmlns + "fo", FoUtils.Namespaces.Fo));
            if (Properties != null) element.Add(new XAttribute(XNamespace.Xmlns + "ibex", FoUtils.Namespaces.Ibex));
        }
        
        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            base.RenderChildren(element, options);
            if (Properties != null) element.Add(Properties.ToXElement(options));
            element.Add(LayoutMasterSet.ToXElement(options));
            foreach (FoPageSequence pageSequence in PageSequences) element.Add(pageSequence.ToXElement(options));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = new XElement(FoUtils.Namespaces.Fo + "root");
            RenderAttributes(element, options);
            RenderChildren(element, options);
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

        public FoPageSequence CreatePageSequence(string masterPageName) {
            return CreatePageSequence(masterPageName, null);
        }

        public FoPageSequence CreatePageSequence(string masterPageName, string id) {
            FoPageSequence page = new FoPageSequence(masterPageName) { Id = id };
            AddPageSequence(page);
            return page;
        }

        /// <summary>
        /// Saves the <strong>XSL-FO</strong> document to the specified <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Save(Stream stream) {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            Save(stream, default(FoRenderOptions));
        }

        public void Save(Stream stream, FoRenderOptions options) {

            if (stream == null) throw new ArgumentNullException(nameof(stream));

            // Convert the document to an instance of "XDocument"
            XDocument document = ToXDocument(options);
            
            // Write the XML to "stream"
            document.Save(stream, options?.SaveOptions ?? SaveOptions.None);

        }

        /// <summary>
        /// Save the <strong>XSL-FO</strong> document to a new stream, and returns that stream.
        /// </summary>
        /// <returns>An instance of <see cref="MemoryStream"/> representing the <strong>XSL-FO</strong> document.</returns>
        public MemoryStream GetStream() {
            return GetStream(default(FoRenderOptions));
        }

        /// <summary>
        /// Save the <strong>XSL-FO</strong> document to a new stream, and returns that stream.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>An instance of <see cref="MemoryStream"/> representing the <strong>XSL-FO</strong> document.</returns>
        public MemoryStream GetStream(FoRenderOptions options) {

            // Initialize a new memory stream
            MemoryStream ms = new MemoryStream();

            // Save the XSL-FO document to the stream
            Save(ms, options);

            // Return the stream.
            return ms;

        }

        #endregion

    }

}