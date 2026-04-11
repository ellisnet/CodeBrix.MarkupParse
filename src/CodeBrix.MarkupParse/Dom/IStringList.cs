using CodeBrix.MarkupParse.Attributes;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom;

/// <summary>
/// Represents a string list.
/// </summary>
[DomName("DOMStringList")]
public interface IStringList :
    IReadOnlyList<string>
{
    /// <summary>
    /// Gets the value at the specified index.
    /// </summary>
    /// <param name="index">The index of the value.</param>
    /// <returns>The string value at the given index.</returns>
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    abstract string IReadOnlyList<string>.this[int index] { get; }

    /// <summary>
    /// Gets the number of entries.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Returns a boolean indicating if the specified entry is available.
    /// </summary>
    /// <param name="entry">The entry that will be looked for.</param>
    /// <returns>
    /// True if the element is available, otherwise false.
    /// </returns>
    [DomName("contains")]
    bool Contains(string entry);

    int IReadOnlyCollection<string>.Count => Length;
}
