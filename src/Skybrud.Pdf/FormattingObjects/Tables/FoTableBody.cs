using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects.Tables {

    public class FoTableBody : FoElement {

        #region Properties

        public FoTableRowCollection Rows { get; } = new FoTableRowCollection();

        #endregion

        #region Constructors

        public FoTableBody() { }

        public FoTableBody(params FoTableRow[] rows) {
            Rows.AddRange(rows);
        }

        #endregion

        #region Member methods
        
        protected override void RenderChildren(XElement element, FoRenderOptions options) {
            base.RenderChildren(element, options);
            foreach (FoTableRow row in Rows) element.Add(row.ToXElement());
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("table-body");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

    }

}