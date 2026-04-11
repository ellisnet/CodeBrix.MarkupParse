using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the col HTML element.
/// </summary>
[DomName("HTMLTableColElement")]
public interface IHtmlTableColumnElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the number of columns in a group or affected by a grouping.
    /// </summary>
    [DomName("span")]
    int Span { get; set; }
}
