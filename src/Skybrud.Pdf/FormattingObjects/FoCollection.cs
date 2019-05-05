using System;
using System.Collections;
using System.Collections.Generic;
using Skybrud.Pdf.FormattingObjects.Pages;

namespace Skybrud.Pdf.FormattingObjects {

    public class FoCollection<T> : IEnumerable<T> {

        private readonly List<T> _list = new List<T>();

        #region Properties

        public int Count => _list.Count;

        #endregion

        #region Constructors

        public FoCollection() { }

        public FoCollection(IEnumerable<T> items) {
            if (items != null) _list.AddRange(items);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds <paramref name="item"/> to the end of the <see cref="FoFlowCollection"/>.
        /// </summary>
        /// <param name="item">The item to be added to the end of the <see cref="FoCollection{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        public void Add(T item) {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _list.Add(item);
        }

        /// <summary>
        /// Adds the flows of the specified <paramref name="collection"/> to the end of the <see cref="FoCollection{T}"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="FoCollection{T}"/>. The collection itself cannot be null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public void AddRange(IEnumerable<T> collection) {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            _list.AddRange(collection);
        }

        /// <summary>
        /// Removes all elements from the <see cref="FoCollection{T}"/>.
        /// </summary>
        public void Clear() {
            _list.Clear();
        }

        /// <summary>
        /// Removes the first occurrence of a <paramref name="item"/> from the <see cref="FoCollection{T}"/>.
        /// </summary>
        /// <param name="item">The item to remove from the <see cref="FoCollection{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        public void Remove(T item) {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _list.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FoCollection{T}"/>.
        /// </summary>
        /// <returns>An enumerator for the <see cref="FoCollection{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}