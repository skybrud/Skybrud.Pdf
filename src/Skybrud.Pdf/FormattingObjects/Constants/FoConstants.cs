using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Constants {

    /// <summary>
    /// Class with various constants used throughout the <strong>XSL-FO</strong> implementation.
    /// </summary>
    public static class FoConstants {

        /// <summary>
        /// Gets the primary namespace of <strong>XSL-FO</strong>.
        /// </summary>
        public static XNamespace Namespace => "http://www.w3.org/1999/XSL/Format";

        /// <summary>
        /// Gets a reference to the <strong>Ibex</strong> namespace.
        /// </summary>
        public static XNamespace NamespaceIbex => "http://www.xmlpdf.com/2003/ibex/Format";

    }

}