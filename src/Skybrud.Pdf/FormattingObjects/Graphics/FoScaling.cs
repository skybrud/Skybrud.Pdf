namespace Skybrud.Pdf.FormattingObjects.Graphics {
    
    /// <summary>
    /// Whether scaling needs to preserve the intrinsic aspect ratio.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#scaling</cref>
    /// </see>
    public enum FoScaling {

        Unspecified,

        /// <summary>
        /// Scaling should preserve the aspect ratio.
        /// </summary>
        Uniform,

        /// <summary>
        /// Scaling need not preserve the aspect ratio.
        /// </summary>
        NonUniform,

        Inherit

    }

}