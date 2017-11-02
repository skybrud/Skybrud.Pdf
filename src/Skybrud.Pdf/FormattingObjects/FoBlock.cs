using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoBlock : FoContainer {

        #region Properties

        public static FoBlock PageBreak {
            get { return new FoBlock { PageBreakBefore = "always" }; }
        }

        #endregion

        #region Constructor(s)

        public FoBlock() {
            // Expose default constructor
        }

        public FoBlock(string text) {
            Add(new FoText(text));
        }

        public FoBlock(IEnumerable<FoBaseElement> elements) {
            AddRange(elements);
        }

        public FoBlock(params FoBaseElement[] elements) {
            AddRange(elements);
        }

        #endregion

        /// <summary>
        /// Appends a new <see cref="FoInline"/> child element containting the specified <paramref name="text"/>.
        /// </summary>
        /// <param name="text">The text of the inline element.</param>
        public void Add(string text) {
            Add(new FoInline(text + ""));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "block");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            return xBlock;
        }

        #region Static methods

        public static FoBlock Init() {
            return new FoBlock();
        }

        public static FoBlock Init(string text) {
            return new FoBlock(text);
        }

        #endregion

    }

    public class FoListBlock : FoBlock {

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "list-block");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            return xBlock;
        }

    }

    public class FoListItem : FoBlock {

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "list-item");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            return xBlock;
        }

    }

    public class FoListItemLabel : FoBlock {

        public string StartIndent { get; set; }
        public string EndIndent { get; set; }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xLabel = new XElement(FoDocument.Namespace + "list-item-label");
            AddAttributes(xLabel);
            AddChildren(xLabel, Elements, options);
            return xLabel;
        }

        protected override IDictionary<string, string> RenderAttributes() {
            var dictionary = base.RenderAttributes();
            if (!String.IsNullOrEmpty(StartIndent)) dictionary.Add("start-indent", StartIndent);
            if (!String.IsNullOrEmpty(EndIndent)) dictionary.Add("end-indent", EndIndent);
            return dictionary;
        }

    }

    public class FoListItemBody : FoBlock {

        public string StartIndent { get; set; }
        public string EndIndent { get; set; }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement xBlock = new XElement(FoDocument.Namespace + "list-item-body");
            AddAttributes(xBlock);
            AddChildren(xBlock, Elements, options);
            return xBlock;
        }

        protected override IDictionary<string, string> RenderAttributes() {
            var dictionary = base.RenderAttributes();
            if (!String.IsNullOrEmpty(StartIndent)) dictionary.Add("start-indent", StartIndent);
            if (!String.IsNullOrEmpty(EndIndent)) dictionary.Add("end-indent", EndIndent);
            return dictionary;
        }

    }

}