namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class representing the text decoration of an element.
    /// </summary>
    /// <see cref="http://www.htmldog.com/references/css/properties/text-decoration/"/>
    /// <see cref="http://www.datypic.com/sc/fo11/a-text-decoration-1.html"/>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#text-decoration</cref>
    /// </see>
    public enum FoTextDecoration {

        Inherit,

        /// <summary>
        /// Produces no text decoration.
        /// </summary>
        None,

        /// <summary>
        /// Each line of text is underlined.
        /// </summary>
        Underline,

        /// <summary>
        /// Each line of text has a line above it.
        /// </summary>
        Overline,

        /// <summary>
        /// Each line of text has a line through the middle
        /// </summary>
        LineThrough

    }

}