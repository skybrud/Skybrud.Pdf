namespace Skybrud.Pdf.FormattingObjects {

    public class FoText : FoBaseElement {
        
        public string Value { get; set; }
        
        public FoText() : this("") {
            // Expose default constructor
        }
        
        public FoText(string value) {
            Value = value;
        }
    
    }

}