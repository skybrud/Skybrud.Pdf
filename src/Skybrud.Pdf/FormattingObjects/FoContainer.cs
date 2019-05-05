using System.Xml.Linq;
using Skybrud.Pdf.FormattingObjects.Styles;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoContainer : FoElement {

        /// <summary>
        /// Gets or sets the alignment, in the block-progression-direction, of the areas that are the children of a
        /// reference-area.
        /// </summary>
        public FoDisplayAlign DisplayAlign { get; set; }

        public string FontFamily { get; set; }

        public string FontSize { get; set; }

        public FoFontWeight FontWeight { get; set; }

        public FoFontStyle FontStyle { get; set; }

        public string Color { get; set; }

        public string PageBreakBefore { get; set; }

        public string Background { get; set; }

        public string BackgroundImage { get; set; }

        public string BackgroundRepeat { get; set; }

        /// <summary>
        /// Gets or sets the keep-together conditions on formatting objects. Default is <see cref="FoKeepTogether.Inherit"/>.
        /// </summary>
        public FoKeepTogether KeepTogether { get; set; }

        public string LineHeight { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Margin { get; set; }
        public string MarginTop { get; set; }
        public string MarginRight { get; set; }
        public string MarginBottom { get; set; }
        public string MarginLeft { get; set; }

        /// <summary>
        /// Gets or sets how inline content of a block should be aligned.
        /// </summary>
        public FoTextAlign TextAlign { get; set; }

        /// <summary>
        /// Gets or sets the decorations that should be added to the text of an element.
        /// </summary>
        public FoTextDecoration TextDecoration { get; set; }

        public string Padding { get; set; }
        public string PaddingTop { get; set; }
        public string PaddingRight { get; set; }
        public string PaddingBottom { get; set; }
        public string PaddingLeft { get; set; }
        public string Border { get; set; }
        public string BorderTop { get; set; }
        public string BorderRight { get; set; }
        public string BorderBottom { get; set; }
        public string BorderLeft { get; set; }
        
        public abstract bool HasChildren { get; }

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {

            base.RenderAttributes(element, options);

            if (DisplayAlign != FoDisplayAlign.Inherit) element.Add(new XAttribute("display-align", ToKebabCase(DisplayAlign)));
            if (!string.IsNullOrEmpty(FontFamily)) element.Add(new XAttribute("font-family", FontFamily));
            if (!string.IsNullOrEmpty(FontSize)) element.Add(new XAttribute("font-size", FontSize));
            if (FontWeight != FoFontWeight.Inherit) element.Add(new XAttribute("font-weight", ToKebabCase(FontWeight)));
            if (FontStyle != FoFontStyle.Inherit) element.Add(new XAttribute("font-style", ToKebabCase(FontStyle)));
            if (TextAlign != FoTextAlign.Inherit) element.Add(new XAttribute("text-align", ToKebabCase(TextAlign)));
            if (TextDecoration != FoTextDecoration.Inherit) element.Add(new XAttribute("text-decoration", ToKebabCase(TextDecoration)));
            if (!string.IsNullOrEmpty(Color)) element.Add(new XAttribute("color", Color));
            if (!string.IsNullOrEmpty(PageBreakBefore)) element.Add(new XAttribute("page-break-before", PageBreakBefore));
            if (!string.IsNullOrEmpty(Background)) element.Add(new XAttribute("background", Background));
            if (!string.IsNullOrEmpty(BackgroundImage)) element.Add(new XAttribute("background-image", BackgroundImage));
            if (!string.IsNullOrEmpty(BackgroundRepeat)) element.Add(new XAttribute("background-repeat", BackgroundRepeat));
            if (KeepTogether != FoKeepTogether.Inherit) element.Add(new XAttribute("keep-together", ToKebabCase(KeepTogether)));
            if (!string.IsNullOrEmpty(LineHeight)) element.Add(new XAttribute("line-height", LineHeight));
            if (!string.IsNullOrEmpty(Width)) element.Add(new XAttribute("width", Width));
            if (!string.IsNullOrEmpty(Height)) element.Add(new XAttribute("height", Height));
            if (!string.IsNullOrEmpty(Margin)) element.Add(new XAttribute("margin", Margin));
            if (!string.IsNullOrEmpty(MarginTop)) element.Add(new XAttribute("margin-top", MarginTop));
            if (!string.IsNullOrEmpty(MarginRight)) element.Add(new XAttribute("margin-right", MarginRight));
            if (!string.IsNullOrEmpty(MarginBottom)) element.Add(new XAttribute("margin-bottom", MarginBottom));
            if (!string.IsNullOrEmpty(MarginLeft)) element.Add(new XAttribute("margin-left", MarginLeft));
            if (!string.IsNullOrEmpty(Padding)) element.Add(new XAttribute("padding", Padding));
            if (!string.IsNullOrEmpty(PaddingTop)) element.Add(new XAttribute("padding-top", PaddingTop));
            if (!string.IsNullOrEmpty(PaddingRight)) element.Add(new XAttribute("padding-right", PaddingRight));
            if (!string.IsNullOrEmpty(PaddingBottom)) element.Add(new XAttribute("padding-bottom", PaddingBottom));
            if (!string.IsNullOrEmpty(PaddingLeft)) element.Add(new XAttribute("padding-left", PaddingLeft));
            if (!string.IsNullOrEmpty(Border)) element.Add(new XAttribute("border", Border));
            if (!string.IsNullOrEmpty(BorderTop)) element.Add(new XAttribute("border-top", BorderTop));
            if (!string.IsNullOrEmpty(BorderRight)) element.Add(new XAttribute("border-right", BorderRight));
            if (!string.IsNullOrEmpty(BorderBottom)) element.Add(new XAttribute("border-bottom", BorderBottom));
            if (!string.IsNullOrEmpty(BorderLeft)) element.Add(new XAttribute("border-left", BorderLeft));

            #endregion

        }

    }

}