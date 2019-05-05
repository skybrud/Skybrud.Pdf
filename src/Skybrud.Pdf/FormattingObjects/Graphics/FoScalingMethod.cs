namespace Skybrud.Pdf.FormattingObjects.Graphics {
    
    /// <summary>
    /// Indicates a preference in the scaling/sizing tradeoff to be used when formatting bitmapped graphics.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#scaling-method</cref>
    /// </see>
    public enum FoScalingMethod {

        Unspecified,

        /// <summary>
        /// The User Agent is free to choose either resampling, integer scaling, or any other scaling method.
        /// </summary>
        Auto,

        /// <summary>
        /// The User Agent should scale the image such that each pixel in the original image is scaled to the nearest
        /// integer number of device-pixels that yields an image less-then-or-equal-to the image size derived from the
        /// content-height, content-width, and scaling properties.
        /// </summary>
        IntegerPixels,

        /// <summary>
        /// The User Agent should resample the supplied image to provide an image that fills the size derived from the
        /// content-height, content-width, and scaling properties. The user agent may use any sampling method.
        /// </summary>
        ResampleAnyMethod,

        Inherit

    }

}