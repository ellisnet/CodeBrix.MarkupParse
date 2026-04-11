using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the menu HTML element.
/// </summary>
[DomName("HTMLMenuElement")]
public interface IHtmlMenuElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the text label of the menu element.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }

    /// <summary>
    /// Gets or sets the type of the menu element.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }
}
