using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the optgroup HTML element.
/// </summary>
[DomName("HTMLOptGroupElement")]
public interface IHtmlOptionsGroupElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets if the optgroup is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }
}
