namespace Skybrud.Pdf.FormattingObjects.Inline {

    public class FoText : FoNode {

        #region Properties
        
        public string Value { get; set; }

        #endregion

        #region Constructors

        public FoText() : this(string.Empty) { }
        
        public FoText(string value) {
            Value = value;
        }

        #endregion

    }

}