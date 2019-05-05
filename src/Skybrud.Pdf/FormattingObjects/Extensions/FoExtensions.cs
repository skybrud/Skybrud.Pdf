using System;
using Skybrud.Pdf.FormattingObjects.Styles;

namespace Skybrud.Pdf.FormattingObjects.Extensions {

    public static class FoExtensions {

        ///// <summary>
        ///// Adds (appends) <see cref="element"/> to <paramref name="parent"/>.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="element">The element to be added.</param>
        ///// <param name="parent">The parent container.</param>
        ///// <returns><paramref name="element"/>.</returns>
        //public static T AddTo<T>(this T element, FoContainer parent) where T : FoContainer {
        //    parent.Add(element);
        //    return element;
        //}

        public static T SetColor<T>(this T container, string color) where T : FoContainer {
            container.Color = color;
            return container;
        }

        public static T SetFontFamily<T>(this T container, string family) where T : FoContainer {
            container.FontFamily = family;
            return container;
        }
        
        public static T SetFontWeight<T>(this T container, FoFontWeight weight) where T : FoContainer {
            container.FontWeight = weight;
            return container;
        }
        
        public static T SetFontStyle<T>(this T container, FoFontStyle style) where T : FoContainer {
            container.FontStyle = style;
            return container;
        }

        public static T SetFontSize<T>(this T container, string value) where T : FoContainer {
            container.FontSize = value;
            return container;
        }

        public static T SetKeepTogether<T>(this T container, FoKeepTogether keep) where T : FoContainer {
            container.KeepTogether = keep;
            return container;
        }

        public static T SetLineHeight<T>(this T container, string value) where T : FoContainer {
            container.LineHeight = value;
            return container;
        }

        public static T SetMarginTop<T>(this T container, string value) where T : FoContainer {
            container.MarginTop = value;
            return container;
        }

        public static T SetMarginRight<T>(this T container, string value) where T : FoContainer {
            container.MarginRight = value;
            return container;
        }

        public static T SetMarginBottom<T>(this T container, string value) where T : FoContainer {
            container.MarginBottom = value;
            return container;
        }

        public static T SetMarginLeft<T>(this T container, string value) where T : FoContainer {
            container.MarginLeft = value;
            return container;
        }

        internal static bool IsDefault(this Enum enumValue) {
            return (int) Convert.ChangeType(enumValue, typeof(int)) == 0;
        }

    }

}