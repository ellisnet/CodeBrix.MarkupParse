using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the details HTML element.
/// </summary>
[DomName("HTMLDetailsElement")]
public interface IHtmlDetailsElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets if the element is opened.
    /// </summary>
    [DomName("open")]
    bool IsOpen { get; set; }
}
