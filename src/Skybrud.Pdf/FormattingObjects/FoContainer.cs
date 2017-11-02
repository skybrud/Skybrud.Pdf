using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Pdf.FormattingObjects.Styles;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoContainer : FoElement {

        private List<FoBaseElement> _elements = new List<FoBaseElement>();

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

        public List<FoBaseElement> Elements => _elements;

        public bool HasChildren => Elements.Count > 0;

        protected static XElement AddChildren(XElement parent, IEnumerable<FoBaseElement> elements, FoRenderOptions options) {

            string lc = parent.Name.LocalName;

            // Certain elements cannot contain text directly
            if (lc == "block-container" || lc == "list-item-label" || lc == "list-item-body") {
                FoText first = elements.FirstOrDefault() as FoText;
                if (elements.Count() == 1 && first != null) {
                    parent.Add(new XElement(FoDocument.Namespace + "block", first.Value));
                    //parent.Add(new FoBlock(first.Value).ToXElement());
                    return parent;
                }
            }

            foreach (FoBaseElement e in elements) {
                if (e is FoElement) {
                    parent.Add(((FoElement)e).ToXElement(options));
                } else if (e is FoText) {
                    if (options == null || options.UseCData) {
                        parent.Add(new XCData(((FoText) e).Value + "")); 
                    } else {
                        parent.Add((((FoText)e).Value + ""));
                    }
                }
            }

            return parent;

        }

        public FoContainer AddRange(IEnumerable<FoBaseElement> elements) {
            foreach (var element in elements) {
                Elements.Add(element);
            }
            return this;
        }

        public FoContainer AddRange(params FoBaseElement[] elements) {
            foreach (var element in elements) {
                Elements.Add(element);
            }
            return this;
        }

        public FoContainer Add(FoBaseElement element) {
            if (element != null) Elements.Add(element);
            return this;
        }
        
        protected virtual IDictionary<string, string> RenderAttributes() {
            var dictionary = new Dictionary<string, string>();
            if (DisplayAlign != FoDisplayAlign.Inherit) dictionary.Add("display-align", ToString(DisplayAlign));
            if (!String.IsNullOrEmpty(FontFamily)) dictionary.Add("font-family", FontFamily);
            if (!String.IsNullOrEmpty(FontSize)) dictionary.Add("font-size", FontSize);
            if (FontWeight != FoFontWeight.Inherit) dictionary.Add("font-weight", ToString(FontWeight));
            if (FontStyle != FoFontStyle.Inherit) dictionary.Add("font-style", ToString(FontStyle));
            if (TextAlign != FoTextAlign.Inherit) dictionary.Add("text-align", ToString(TextAlign));
            if (TextDecoration != FoTextDecoration.Inherit) dictionary.Add("text-decoration", ToString(TextDecoration));
            if (!String.IsNullOrEmpty(Color)) dictionary.Add("color", Color);
            if (!String.IsNullOrEmpty(PageBreakBefore)) dictionary.Add("page-break-before", PageBreakBefore);
            if (!String.IsNullOrEmpty(Background)) dictionary.Add("background", Background);
            if (!String.IsNullOrEmpty(BackgroundImage)) dictionary.Add("background-image", BackgroundImage);
            if (!String.IsNullOrEmpty(BackgroundRepeat)) dictionary.Add("background-repeat", BackgroundRepeat);
            if (KeepTogether != FoKeepTogether.Inherit) dictionary.Add("keep-together", ToString(KeepTogether));
            if (!String.IsNullOrEmpty(LineHeight)) dictionary.Add("line-height", LineHeight);
            if (!String.IsNullOrEmpty(Width)) dictionary.Add("width", Width);
            if (!String.IsNullOrEmpty(Height)) dictionary.Add("height", Height);
            if (!String.IsNullOrEmpty(Margin)) dictionary.Add("margin", Margin);
            if (!String.IsNullOrEmpty(MarginTop)) dictionary.Add("margin-top", MarginTop);
            if (!String.IsNullOrEmpty(MarginRight)) dictionary.Add("margin-right", MarginRight);
            if (!String.IsNullOrEmpty(MarginBottom)) dictionary.Add("margin-bottom", MarginBottom);
            if (!String.IsNullOrEmpty(MarginLeft)) dictionary.Add("margin-left", MarginLeft);
            if (!String.IsNullOrEmpty(Padding)) dictionary.Add("padding", Padding);
            if (!String.IsNullOrEmpty(PaddingTop)) dictionary.Add("padding-top", PaddingTop);
            if (!String.IsNullOrEmpty(PaddingRight)) dictionary.Add("padding-right", PaddingRight);
            if (!String.IsNullOrEmpty(PaddingBottom)) dictionary.Add("padding-bottom", PaddingBottom);
            if (!String.IsNullOrEmpty(PaddingLeft)) dictionary.Add("padding-left", PaddingLeft);
            if (!String.IsNullOrEmpty(Border)) dictionary.Add("border", Border);
            if (!String.IsNullOrEmpty(BorderTop)) dictionary.Add("border-top", BorderTop);
            if (!String.IsNullOrEmpty(BorderRight)) dictionary.Add("border-right", BorderRight);
            if (!String.IsNullOrEmpty(BorderBottom)) dictionary.Add("border-bottom", BorderBottom);
            if (!String.IsNullOrEmpty(BorderLeft)) dictionary.Add("border-left", BorderLeft);
            return dictionary;
        }

        protected void AddAttributes(XElement e) {
            foreach (var pair in RenderAttributes()) {
                e.Add(new XAttribute(pair.Key, pair.Value));
            }
        }

        protected string ToString(Enum value) {
            return StringUtils.ToUnderscore(value).Replace("_", "-");
        }

    }

}