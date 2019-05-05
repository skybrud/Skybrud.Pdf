using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Pdf.FormattingObjects.Inline;

namespace Skybrud.Pdf.FormattingObjects {

    public abstract class FoContainer<T> : FoContainer where T : FoNode {
        
        #region Properties

        public List<T> Children { get; } = new List<T>();

        public override bool HasChildren => Children.Count > 0;

        #endregion

        #region Member methods

        public FoContainer AddRange(IEnumerable<T> children) {
            Children.AddRange(children);
            return this;
        }

        public FoContainer AddRange(params T[] children) {
            Children.AddRange(children);
            return this;
        }

        public FoContainer Add(T child) {
            Children.Add(child);
            return this;
        }

        protected override void RenderChildren(XElement element, FoRenderOptions options) {

            foreach (FoNode node in Children) {

                switch (node) {

                    case FoElement child:
                        element.Add(child.ToXElement(options));
                        break;

                    case FoText text when options == null || options.UseCData:
                        element.Add(new XCData(text.Value ?? string.Empty));
                        break;

                    case FoText text:
                        element.Add(text.Value ?? string.Empty);
                        break;

                }

            }

        }

        #endregion

    }

}