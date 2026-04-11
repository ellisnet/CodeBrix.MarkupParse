using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The PseudoElement interface is used for representing CSS
/// pseudo-elements.
/// </summary>
[DomName("PseudoElement")]
[DomNoInterfaceObject]
public interface IPseudoElement : IElement
{
    /// <summary>
    /// Gets the assigned pseudo name (e.g., before).
    /// </summary>
    string PseudoName { get; }
}
