using System.Xml.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// Specifies how to create a (sub-)sequence of pages within a document; for example, a chapter of a report. The
    /// content of these pages comes from flow children of the <c>fo:page-sequence</c>. Specifies that only the
    /// children of <c>fo:markers</c> that are descendants of any <c>fo:flow</c> within the containing
    /// <c>fo:page-sequence</c> may be retrieved by this <c>fo:retrieve-marker</c>.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_page-sequence</cref>
    /// </see>
    public class FoPageSequence : FoElement {

        #region Properties

        /// <summary>
        /// The names need not be unique, but may not be empty and must refer to a master-name that exists within the
        /// document.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#master-reference</cref>
        /// </see>
        public string MasterReference { get; set; }

        /// <summary>
        /// An identifier unique within all objects in the result tree with the <c>fo:</c> namespace. It allows
        /// references to this formatting object by other objects.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#id</cref>
        /// </see>
        public string Id { get; set; }

        // TODO: Add support for <fo:title/>

        /// <summary>
        /// A sequence or a tree of formatting objects that is to be presented in a single region or repeated in
        /// like-named regions on one or more pages in the page-sequence. Its common use is for repeating or running
        /// headers and footers.
        /// </summary>
        public FoStaticContentCollection StaticContent { get; } = new FoStaticContentCollection();

        /// <summary>
        /// A sequence of flow objects that provides the flowing text content that is distributed into pages.
        /// </summary>
        public FoFlowCollection Flows { get; } = new FoFlowCollection();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new page sequence with default options.
        /// </summary>
        public FoPageSequence() { }
        
        /// <summary>
        /// Initializes a new page sequence with the specified <paramref name="masterReference"/>.
        /// </summary>
        /// <param name="masterReference">The name of the master page.</param>
        public FoPageSequence(string masterReference) {
            MasterReference = masterReference;
        }

        /// <summary>
        /// Initializes a new page sequence with the specified <paramref name="masterReference"/>.
        /// </summary>
        /// <param name="masterReference">The name of the master page.</param>
        /// <param name="flows">A collection of flows to be added to the page sequence.</param>
        public FoPageSequence(string masterReference, params FoFlow[] flows) {
            MasterReference = masterReference;
            Flows.AddRange(flows);
        }

        /// <summary>
        /// Initializes a new page sequence with the specified <paramref name="masterReference"/>.
        /// </summary>
        /// <param name="masterReference">The name of the master page.</param>
        /// <param name="id">The ID of the page sequence.</param>
        /// <param name="flows">A collection of flows to be added to the page sequence.</param>
        public FoPageSequence(string masterReference, string id, params FoFlow[] flows) {
            MasterReference = masterReference;
            Id = id;
            Flows.AddRange(flows);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {

            base.RenderAttributes(element, options);

            if (MasterReference.IsNullOrWhiteSpace()) throw new PropertyNotSetException(nameof(MasterReference));
            element.Add(new XAttribute("master-reference", MasterReference));

            if (Id.HasValue()) element.Add(new XAttribute("id", Id));

        }

        /// <inheritdoc />
        protected override void RenderChildren(XElement element, FoRenderOptions options) {

            base.RenderChildren(element, options);

            foreach (FoStaticContent staticContent in StaticContent) element.Add(staticContent.ToXElement(options));
            foreach (FoFlow flow in Flows) element.Add(flow.ToXElement(options));

        }

        /// <inheritdoc />
        public override XElement ToXElement(FoRenderOptions options) {

            XElement element = Fo("page-sequence");

            RenderAttributes(element, options);
            RenderChildren(element, options);

            return element;

        }

        #endregion

    }

}