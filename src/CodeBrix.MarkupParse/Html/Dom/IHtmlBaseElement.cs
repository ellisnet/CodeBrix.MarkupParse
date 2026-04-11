using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base HTML element.
/// </summary>
[DomName("HTMLBaseElement")]
public interface IHtmlBaseElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the hyperreference to the base URL.
    /// </summary>
    [DomName("href")]
    string Href { get; set; }

    /// <summary>
    /// Gets or sets the base target.
    /// </summary>
    [DomName("target")]
    string Target { get; set; }
}
