using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Pdf.FormattingObjects.Inline;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoBlock : FoContainer<FoNode> {

        #region Properties

        public static FoBlock PageBreak => new FoBlock { PageBreakBefore = "always" };

        #endregion

        #region Constructor(s)

        public FoBlock() { }

        public FoBlock(string text) {
            Add(new FoText(text));
        }

        public FoBlock(IEnumerable<FoNode> children) {
            AddRange(children);
        }

        public FoBlock(params FoNode[] children) {
            AddRange(children);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Appends a new <see cref="FoInline"/> child element containting the specified <paramref name="text"/>.
        /// </summary>
        /// <param name="text">The text of the inline element.</param>
        public void Add(string text) {
            Add(new FoInline(text ?? string.Empty));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = Fo("block");
            RenderAttributes(xBlock, options);
            RenderChildren(xBlock, options);
            return xBlock;
        }

        #endregion

        #region Static methods

        public static FoBlock Init() {
            return new FoBlock();
        }

        public static FoBlock Init(string text) {
            return new FoBlock(text);
        }

        #endregion

    }

}