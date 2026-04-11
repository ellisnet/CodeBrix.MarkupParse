using CodeBrix.MarkupParse.Css.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// Describes the interface for visiting a selector.
/// </summary>
public interface ISelectorVisitor
{
    /// <summary>
    /// Visited by attribute selectors.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="op">The operator, if any.</param>
    /// <param name="value">The value, if any.</param>
    void Attribute(string name, string op, string value);

    /// <summary>
    /// Visited by type selectors.
    /// </summary>
    /// <param name="name">The name of the type or *.</param>
    void Type(string name);

    /// <summary>
    /// Visited by id selectors.
    /// </summary>
    /// <param name="value">The value of the id.</param>
    void Id(string value);

    /// <summary>
    /// Visited by child selectors.
    /// </summary>
    /// <param name="name">The name of the selector.</param>
    /// <param name="step">The step parameter.</param>
    /// <param name="offset">The offset parameter.</param>
    /// <param name="selector">The applied inner selector, if any.</param>
    void Child(string name, int step, int offset, ISelector selector);

    /// <summary>
    /// Visited by class selectors.
    /// </summary>
    /// <param name="name">The name of the class.</param>
    void Class(string name);

    /// <summary>
    /// Visited by pseudo-class selectors.
    /// </summary>
    /// <param name="name">The name of the pseudo class.</param>
    void PseudoClass(string name);

    /// <summary>
    /// Visited by pseudo-element selectors.
    /// </summary>
    /// <param name="name">The name of the pseudo element.</param>
    void PseudoElement(string name);

    /// <summary>
    /// Visited by comma-separated list selectors.
    /// </summary>
    /// <param name="selectors">The contained selectors.</param>
    void List(IEnumerable<ISelector> selectors);

    /// <summary>
    /// Visited by combinator selectors.
    /// </summary>
    /// <param name="selectors">The contained N selectors.</param>
    /// <param name="symbols">The N - 1 combinator symbols.</param>
    void Combinator(IEnumerable<ISelector> selectors, IEnumerable<string> symbols);

    /// <summary>
    /// Visited by aggregated / combined selectors.
    /// </summary>
    /// <param name="selectors">The combined selectors.</param>
    void Many(IEnumerable<ISelector> selectors);
}
