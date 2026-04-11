using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the title HTML element.
/// </summary>
[DomName("HTMLTitleElement")]
public interface IHtmlTitleElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the text of the title.
    /// </summary>
    [DomName("text")]
    string Text { get; set; }
}
