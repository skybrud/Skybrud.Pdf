using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects {

    /// <summary>
    /// The start resource of a simple link.
    /// </summary>
    public class FoBasicLink : FoBlock {

        #region Properties

        /// <summary>
        /// The destination flow object within the formatting object tree. This property allows the destination flow
        /// object node to be explicitly specified.
        /// </summary>
        public string InternalDestination { get; set; }

        /// <summary>
        /// The destination resource (or, when a fragment identifier is given, sub-resource).
        /// </summary>
        public string ExternalDestination { get; set; }

        #endregion

        #region Constructors

        public FoBasicLink() { }

        public FoBasicLink(string text) : base(text) { }

        public FoBasicLink(IEnumerable<FoNode> children) : base(children) { }

        public FoBasicLink(params FoNode[] children) : base(children) { }

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (InternalDestination.HasValue()) element.Add(new XAttribute("internal-destination", InternalDestination));
            if (ExternalDestination.HasValue()) element.Add(new XAttribute("external-destination", ExternalDestination));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("basic-link");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

    }

}
