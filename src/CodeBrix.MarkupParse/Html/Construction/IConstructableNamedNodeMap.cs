using CodeBrix.MarkupParse.Common;
using System;

namespace CodeBrix.MarkupParse.Html.Construction;

/// <summary>
/// Represents a constructable named node map. (Attributes)
/// </summary>
public interface IConstructableNamedNodeMap
{
    /// <summary>
    /// Tried to get the attribute with the given name.
    /// </summary>
    IConstructableAttr this[StringOrMemory name] { get; }

    /// <summary>
    /// Total amount of attributes.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Checks if the given attributes are the same.
    /// </summary>
    /// <param name="attributes">Other attributes to compare against</param>
    bool SameAs(IConstructableNamedNodeMap attributes);
}
