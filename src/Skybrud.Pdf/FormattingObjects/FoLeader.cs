using System.Xml.Linq;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Pdf.FormattingObjects.Styles;

namespace Skybrud.Pdf.FormattingObjects {
    
    /// <summary>
    /// Generates leaders consisting either of a rule or of a row of a repeating character or cyclically repeating
    /// pattern of characters that may be used for connecting two text formatting objects.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xsl11/#fo_leader</cref>
    /// </see>
    public class FoLeader : FoElement {

        #region Properties

        /// <summary>
        /// How to fill in the leader.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#leader-pattern</cref>
        /// </see>
        public FoLeaderPattern LeaderPattern;

        /// <summary>
        /// The minimum, optimum, and maximum length of an fo:leader.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#leader-length</cref>
        /// </see>
        public string LeaderLength;

        /// <summary>
        /// The overall thickness of the rule.
        /// </summary>
        /// <see cref="https://www.w3.org/TR/xsl11/#rule-thickness"/>
        public string Thickness;

        /// <summary>
        /// The foreground color of an element's text content.
        /// </summary>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xsl11/#color</cref>
        /// </see>
        public string Color;

        public static FoLeader HorizontalRuler => new FoLeader { LeaderPattern = FoLeaderPattern.Rule, LeaderLength = "100%", Thickness = "1px" };

        #endregion

        #region Member methods

        protected override void RenderAttributes(XElement element, FoRenderOptions options) {
            base.RenderAttributes(element, options);
            if (LeaderPattern != FoLeaderPattern.Unspecified) element.Add(new XAttribute("leader-pattern", ToKebabCase(LeaderPattern)));
            if (LeaderLength.HasValue()) element.Add(new XAttribute("leader-length", LeaderLength));
            if (Thickness.HasValue()) element.Add(new XAttribute("rule-thickness", Thickness));
            if (Color.HasValue()) element.Add(new XAttribute("color", Color));
        }

        public override XElement ToXElement(FoRenderOptions options) {
            XElement element = Fo("leader");
            RenderAttributes(element, options);
            RenderChildren(element, options);
            return element;
        }

        #endregion

    }

}