using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the li HTML element.
/// </summary>
[DomName("HTMLLIElement")]
public interface IHtmlListItemElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the value in an ordered list.
    /// </summary>
    [DomName("value")]
    int? Value { get; set; }
}
