using System;
using System.Xml.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Pdf.FormattingObjects.Styles;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoElement : FoNode {

        #region Member methods

        protected XElement Fo(string name) {
            return new XElement(FoUtils.Namespaces.Fo + name);
        }

        protected XElement Ibex(string name) {
            return new XElement(FoUtils.Namespaces.Ibex + name);
        }

        /// <summary>
        /// Returns an <see cref="XElement"/> representation of the element using default formatting options.
        /// </summary>
        /// <returns>The <see cref="XElement"/> representing the element.</returns>
        public XElement ToXElement() {
            return ToXElement(default(FoRenderOptions));
        }

        /// <summary>
        /// Returns an <see cref="XElement"/> representation of the element using the specified formatting <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for rendering the element.</param>
        /// <returns>The <see cref="XElement"/> representing the element.</returns>
        public abstract XElement ToXElement(FoRenderOptions options);

        /// <summary>
        /// Returns a string representation of the element using default formatting options.
        /// </summary>
        /// <returns>The string representing the element.</returns>
        public override string ToString() {
            return ToXElement().ToString();
        }

        /// <summary>
        /// Returns a string representation of the element using the specified formatting <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for rendering the element.</param>
        /// <returns>The string representing the element.</returns>
        public string ToString(FoRenderOptions options) {
            return ToXElement(options).ToString(options?.SaveOptions ?? SaveOptions.None);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a kebab cased string (lowercase words separated by hyphens).
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The string representing the enum value.</returns>
        protected string ToKebabCase(Enum value) {
            return StringUtils.ToUnderscore(value).Replace("_", "-");
        }

        /// <summary>
        /// Renders the attributes of the element.
        /// </summary>
        /// <param name="element">The element to be rendered.</param>
        /// <param name="options">The options for rendering the element.</param>
        protected virtual void RenderAttributes(XElement element, FoRenderOptions options) { }

        /// <summary>
        /// Renders the children of the element.
        /// </summary>
        /// <param name="element">The element to be rendered.</param>
        /// <param name="options">The options for rendering the element.</param>
        protected virtual void RenderChildren(XElement element, FoRenderOptions options) { }

        #endregion

    }

}