using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the ol HTML element.
/// </summary>
[DomName("HTMLOListElement")]
public interface IHtmlOrderedListElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets if the order is reversed.
    /// </summary>
    [DomName("reversed")]
    bool IsReversed { get; set; }

    /// <summary>
    /// Gets or sets the lowest number.
    /// </summary>
    [DomName("start")]
    int Start { get; set; }

    /// <summary>
    /// Gets or sets the type of enumeration.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }
}
