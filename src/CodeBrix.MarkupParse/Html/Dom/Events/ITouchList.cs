using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents a list with touch points.
/// </summary>
[DomName("TouchList")]
public interface ITouchList
{
    /// <summary>
    /// Gets the number of contained touch points.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets the data of the touch point at the given index.
    /// </summary>
    /// <param name="index">The index of the touch point.</param>
    /// <returns>The touch point at the index.</returns>
    [DomAccessor(Accessors.Getter)]
    [DomName("item")]
    ITouchPoint this[int index] { get; }
}
