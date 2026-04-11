using CodeBrix.MarkupParse.Css.Dom;
using System;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// Represents a factory for pseudo-class selectors.
/// </summary>
public interface IPseudoClassSelectorFactory
{
    /// <summary>
    /// Creates a new pseudo-class selector for the given name.
    /// </summary>
    /// <param name="name">The name of the pseudo-class.</param>
    /// <returns>The created selector, if any.</returns>
    ISelector Create(string name);
}
