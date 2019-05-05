namespace Skybrud.Pdf.FormattingObjects.Pages {
    
    /// <summary>
    /// Determines what set of page areas are considered by a page number citation formatting object.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#page-citation-strategy</cref>
    /// </see>
    public enum FoPageCitationStrategy {
        Inherit,
        All,
        Normal,
        NonBlank
    }

}