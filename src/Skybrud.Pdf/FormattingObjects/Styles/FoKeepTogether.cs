namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class indicating the keep-together conditions on formatting objects.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#keep-together</cref>
    /// </see>
    /// <see cref="http://www.datypic.com/sc/fo11/a-keep-together-1.html"/>
    public enum FoKeepTogether {

        Inherit,

        /// <summary>
        /// Imposes a keep-together condition with strength "always" in the appropriate context.
        /// </summary>
        Always

    }

}