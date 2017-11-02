namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class representing the font style of an element. Only supports <see cref="Normal"/> and
    /// <see cref="Italic"/> for now.
    /// </summary>
    /// <see cref="http://www.datypic.com/sc/fo11/a-font-style-1.html"/>
    /// <see cref="http://www.htmldog.com/references/css/properties/font-style/"/>
    public enum FoFontStyle {

        Inherit,

        Normal,
        
        Italic
    
    }

}