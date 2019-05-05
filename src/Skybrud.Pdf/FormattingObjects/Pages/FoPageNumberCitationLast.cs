using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// References the page-number for the last page containing the an area that is (a) returned by the cited
    /// formatting object and (b) has an area-class that is consistent with the specified page-citation-strategy.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_page-number-citation-last</cref>
    /// </see>
    public class FoPageNumberCitationLast : FoElement {

        #region Properties

        /// <summary>
        /// Determines what set of page areas are considered by a page number citation formatting object.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#page-citation-strategy</cref>
        /// </see>
        public FoPageCitationStrategy PageCitationStrategy { get; set; }

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
        public FoPageNumberCitationLast() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="referenceId"/>.
        /// </summary>
        /// <param name="referenceId">Reference to the object having the specified unique identifier.</param>
        public FoPageNumberCitationLast(string referenceId) {
            ReferenceId = referenceId;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="pageCitationStrategy"/>.
        /// </summary>
        /// <param name="pageCitationStrategy">Determines what set of page areas are considered by a page number citation formatting object.</param>
        public FoPageNumberCitationLast(FoPageCitationStrategy pageCitationStrategy) {
            PageCitationStrategy = pageCitationStrategy;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="referenceId"/> and <paramref name="pageCitationStrategy"/>.
        /// </summary>
        /// <param name="pageCitationStrategy">Determines what set of page areas are considered by a page number citation formatting object.</param>
        /// <param name="referenceId">Reference to the object having the specified unique identifier.</param>
        public FoPageNumberCitationLast(FoPageCitationStrategy pageCitationStrategy, string referenceId) {
            PageCitationStrategy = pageCitationStrategy;
            ReferenceId = referenceId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc/>
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (PageCitationStrategy != FoPageCitationStrategy.Inherit) element.Add(new XAttribute("page-citation-strategy", ToKebabCase(PageCitationStrategy)));
            if (ReferenceId.HasValue()) element.Add(new XAttribute("ref-id", ReferenceId));
        }

        /// <inheritdoc/>
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("page-number-citation-last");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}