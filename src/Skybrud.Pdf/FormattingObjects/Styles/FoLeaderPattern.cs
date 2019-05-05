namespace Skybrud.Pdf.FormattingObjects.Styles {
    
    /// <summary>
    /// How to fill in the leader.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#leader-pattern</cref>
    /// </see>
    public enum FoLeaderPattern {

        Unspecified,

        /// <summary>
        /// Blank space.
        /// </summary>
        Space,

        /// <summary>
        /// A rule. If this choice is selected, the "rule-thickness" and "rule-style" properties are used to set the leader's style.
        /// </summary>
        Rule,

        /// <summary>
        /// A repeating sequence of dots. The choice of dot character is dependent on the user agent.
        /// </summary>
        Dots,

        /// <summary>
        /// A repeating pattern as specified by the children of the <c>fo:leader</c>.
        /// </summary>
        UseContent,

        Inherit

    }

}