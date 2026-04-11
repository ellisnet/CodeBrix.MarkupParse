using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html.Construction;

/// <summary>
/// Represents a constructable node list. (Children)
/// </summary>
public interface IConstructableNodeList : IEnumerable<IConstructableNode>
{
    /// <summary>
    /// Returns an item in the list by its index, or throws an exception.
    /// </summary>
    IConstructableNode this[int index] { get; }

    /// <summary>
    /// Length of the list.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Clears the list.
    /// </summary>
    void Clear();
}