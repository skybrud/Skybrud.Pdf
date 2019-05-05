using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// A sequence of flow objects that provides the flowing text content that is distributed into pages.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_flow</cref>
    /// </see>
    public class FoFlow : FoContainer<FoElement> {

        #region Properties

        /// <summary>
        /// An identifier unique within all objects in the result tree with the <c>fo:</c> namespace. It allows
        /// references to this formatting object by other objects.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#id</cref>
        /// </see>
        public string Id { get; set; }

        /// <summary>
        /// The name of the flow.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#flow-name</cref>
        /// </see>
        public string FlowName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new flow with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        public FoFlow(string name) {
            FlowName = name;
        }

        /// <summary>
        /// Initializes a new flow with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        /// <param name="children">A collection of <see cref="FoElement"/> to be added to the flow.</param>
        public FoFlow(string name, IEnumerable<FoElement> children) {
            FlowName = name;
            AddRange(children);
        }

        /// <summary>
        /// Initializes a new flow with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        /// <param name="children">A collection of <see cref="FoElement"/> to be added to the flow.</param>
        public FoFlow(string name, params FoElement[] children) {
            FlowName = name;
            AddRange(children);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (Id.HasValue()) element.Add(new XAttribute("id", Id));
            if (FlowName.HasValue()) element.Add(new XAttribute("flow-name", FlowName));
        }

        /// <inheritdoc />
        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("flow");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

    }

}