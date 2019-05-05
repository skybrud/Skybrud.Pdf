using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    public class FoStaticContent : FoContainer<FoElement> {

        #region Properties

        /// <summary>
        /// An identifier unique within all objects in the result tree with the <c>fo:</c> namespace. It allows
        /// references to this formatting object by other objects.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Associates an index class with a formatting object that also has an index key specified.
        /// </summary>
        public string IndexClass { get; set; }

        /// <summary>
        /// Associates an index key with the formatting object on which it is specified.
        /// </summary>
        public string IndexKey { get; set; }

        /// <summary>
        /// The name of the flow.
        /// </summary>
        public string FlowName { get; set; }

        #endregion

        #region Constructors

        public FoStaticContent(string name) {
            FlowName = name;
        }

        public FoStaticContent(string name, IEnumerable<FoElement> elements) {
            FlowName = name;
            AddRange(elements);
        }

        public FoStaticContent(string name, params FoElement[] elements) {
            FlowName = name;
            AddRange(elements);
        }

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (Id.HasValue()) element.Add(new XAttribute("id", Id));
            if (IndexClass.HasValue()) element.Add(new XAttribute("index-class", IndexClass));
            if (IndexKey.HasValue()) element.Add(new XAttribute("index-key", IndexKey));
            if (FlowName.HasValue()) element.Add(new XAttribute("flow-name", FlowName));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("static-content");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}
