using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the q HTML element.
/// </summary>
[DomName("HTMLQuoteElement")]
public interface IHtmlQuoteElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the citation of the element.
    /// </summary>
    [DomName("cite")]
    string Citation { get; set; }
}
