using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Pdf.FormattingObjects.Ibex {
    
    public class IbexProperties : FoElement {

        #region Properties

        /// <summary>
        /// Specifies a string which becomes the title property of the document.

        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Specifies a string which becomes the subject property of the document.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Specifies a string which becomes the author property of the document.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Specifies a string which becomes the keywords property of the document.
        /// </summary>
        public string[] Keywords { get; set; }

        /// <summary>
        /// Specifies a string which becomes the creator property of the document. This should be the name of the
        /// application which created the XSL-FO document from which the PDF file was created.
        /// </summary>
        public string Creator { get; set; }

        #endregion

        #region Member methods
        
        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (Title.HasValue()) element.Add(new XAttribute("title", Title));
            if (Author.HasValue()) element.Add(new XAttribute("author", Author));
            if (Subject.HasValue()) element.Add(new XAttribute("subject", Subject));
            if (Keywords != null && Keywords.Length > 0) element.Add(new XAttribute("title", string.Join(",", Keywords)));
            if (Creator.HasValue()) element.Add(new XAttribute("creator", Creator));
        }
        
        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Ibex("properties");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}