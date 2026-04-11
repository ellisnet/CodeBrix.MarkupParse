using CodeBrix.MarkupParse.Css.Dom;
using System;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// Represents a factory for pseudo-element selectors.
/// </summary>
public interface IPseudoElementSelectorFactory
{
    /// <summary>
    /// Creates a new pseudo-element selector for the given name.
    /// </summary>
    /// <param name="name">The name of the pseudo-element.</param>
    /// <returns>The created selector, if any.</returns>
    ISelector Create(string name);
}
