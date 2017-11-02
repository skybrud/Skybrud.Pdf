namespace Skybrud.Pdf.FormattingObjects.Styles {

    /// <summary>
    /// Enum class indicating the alignment, in the block-progression-direction, of the areas that are the children of
    /// a reference-area.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#display-align</cref>
    /// </see>
    public enum FoDisplayAlign {

        Inherit,

        /// <summary>
        /// If the "relative-align" property applies to this formatting object the "relative-align" property is used.
        /// If not, this value is treated as if "before" had been specified.
        /// </summary>
        Auto,

        /// <summary>
        /// The before-edge of the allocation-rectangle of the first child area is placed coincident with the
        /// before-edge of the content-rectangle of the reference-area.
        /// </summary>
        Before,

        /// <summary>
        /// The child areas are placed such that the distance between the before-edge of the allocation-rectangle of
        /// the first child area and the before-edge of the content-rectangle of the reference-area is the same as the
        /// distance between the after-edge of the allocation-rectangle of the last child area and the after-edge of
        /// the content-rectangle of the reference-area.
        /// </summary>
        Center,

        /// <summary>
        /// The after-edge of the allocation-rectangle of the last child area is placed coincident with the after-edge
        /// of the content-rectangle of the reference-area.
        /// </summary>
        After

    }

}