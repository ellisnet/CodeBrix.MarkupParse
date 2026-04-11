using CodeBrix.MarkupParse.Attributes;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom;

/// <summary>
/// HTMLCollection is an interface representing a generic collection
/// (array) of elements (in document order) and offers methods and
/// properties for selecting from the list.
/// </summary>
[DomName("HTMLCollection")]
public interface IHtmlCollection<T> :
    IReadOnlyList<T>
    where T : IElement
{
    /// <summary>
    /// Gets the number of items in the collection.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets the specific node at the given zero-based index into the list.
    /// </summary>
    /// <param name="index">The zero-based index.</param>
    /// <returns>Returns the element at the specified index.</returns>
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    abstract T IReadOnlyList<T>.this[int index] { get; }

    /// <summary>
    /// Gets the specific node whose ID or, as a fallback, name matches the
    /// string specified by name. Matching by name is only done as a last
    /// resort, only in HTML, and only if the referenced element supports 
    /// the name attribute.
    /// </summary>
    /// <param name="id">The id or name to match.</param>
    /// <returns>Returns the element with the specified name.</returns>
    [DomName("namedItem")]
    [DomAccessor(Accessors.Getter)]
    T this[string id] { get; }

    int IReadOnlyCollection<T>.Count => Length;
}
