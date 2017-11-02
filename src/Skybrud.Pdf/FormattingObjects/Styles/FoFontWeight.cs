namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class representing the font weight of an element. Only supports <see cref="Normal"/> and
    /// <see cref="Bold"/> for now.
    /// </summary>
    /// <see cref="http://www.htmldog.com/references/css/properties/font-weight/"/>
    /// <see cref="http://www.datypic.com/sc/fo11/a-font-weight-1.html"/>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#font-weight</cref>
    /// </see>
    public enum FoFontWeight {
        Inherit,
        Normal,
        Bold
    }

}