namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class indicating how inline content of a block should be aligned.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#text-align</cref>
    /// </see>
    /// <see cref="http://www.datypic.com/sc/fo11/a-text-align-1.html"/>
    public enum FoTextAlign {

        Inherit,

        /// <summary>
        /// Specifies that the content is to be aligned on the start-edge in the inline-progression-direction.
        /// </summary>
        Start,

        /// <summary>
        /// Specifies that the content is to be centered in the inline-progression-direction.
        /// </summary>
        Center,

        /// <summary>
        /// Specifies that the content is to be aligned on the end-edge in the inline-progression-direction.
        /// </summary>
        End,

        /// <summary>
        /// Specifies that the contents is to be expanded to fill the available width in the inline-progression-direction.
        /// </summary>
        Justify,

        /// <summary>
        /// If the page binding edge is on the start-edge, the alignment will be start. If the binding is the end-edge, the alignment will be end. If neither, use start alignment.
        /// </summary>
        Inside,

        /// <summary>
        /// If the page binding edge is on the start-edge, the alignment will be end. If the binding is the end-edge, the alignment will be start. If neither, use end alignment.
        /// </summary>
        Outside,

        /// <summary>
        /// Interpreted as <code>text-align='start'</code>.
        /// </summary>
        Left,

        /// <summary>
        /// Interpreted as <code>text-align='end'</code>.
        /// </summary>
        Right

    }

}
