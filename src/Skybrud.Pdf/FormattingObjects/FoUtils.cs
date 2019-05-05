using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public static class FoUtils {

        public static class Elements {

            public static FoBlock PageBreak => FoBlock.PageBreak;

            public static FoLeader HorizontalRuler => FoLeader.HorizontalRuler;

        }

        public static class Namespaces {
            
            public static XNamespace Fo => "http://www.w3.org/1999/XSL/Format";

            public static XNamespace Ibex => "http://www.xmlpdf.com/2003/ibex/Format";

        }

    }

}