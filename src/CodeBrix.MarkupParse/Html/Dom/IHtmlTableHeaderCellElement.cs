using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the th HTML element.
/// </summary>
[DomName("HTMLTableHeaderCellElement")]
public interface IHtmlTableHeaderCellElement : IHtmlTableCellElement
{
    /// <summary>
    /// Gets or sets the scope of the th element.
    /// </summary>
    [DomName("scope")]
    string Scope { get; set; }
}
