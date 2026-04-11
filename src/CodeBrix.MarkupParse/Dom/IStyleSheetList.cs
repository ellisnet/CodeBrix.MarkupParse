using CodeBrix.MarkupParse.Attributes;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a list of stylesheet elements.
/// </summary>
[DomName("StyleSheetList")]
public interface IStyleSheetList : IEnumerable<IStyleSheet>
{
    /// <summary>
    /// Gets the stylesheet at the specified index. If index is greater
    /// than or equal to the number of style sheets in the list, this
    /// returns null.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <returns>The stylesheet.</returns>
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    IStyleSheet this[int index] { get; }
    
    /// <summary>
    /// Gets the number of elements in the list of stylesheets.
    /// </summary>
    [DomName("length")]
    int Length { get; }
}
