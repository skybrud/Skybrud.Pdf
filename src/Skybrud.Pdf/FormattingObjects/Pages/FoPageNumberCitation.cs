using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Pages {

    /// <summary>
    /// References the page-number for the page containing the first normal area returned by the cited formatting object.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_page-number-citation</cref>
    /// </see>
    public class FoPageNumberCitation : FoElement {

        #region Properties

        /// <summary>
        /// Reference to the object having the specified unique identifier.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#ref-id</cref>
        /// </see>
        public string ReferenceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FoPageNumberCitation() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="referenceId"/>.
        /// </summary>
        /// <param name="referenceId">Reference to the object having the specified unique identifier.</param>
        public FoPageNumberCitation(string referenceId) {
            ReferenceId = referenceId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc/>
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (ReferenceId.HasValue()) element.Add(new XAttribute("ref-id", ReferenceId));
        }

        /// <inheritdoc/>
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("page-number-citation");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}