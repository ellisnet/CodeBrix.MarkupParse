using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the time HTML element.
/// </summary>
[DomName("HTMLTimeElement")]
public interface IHtmlTimeElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the time.
    /// </summary>
    [DomName("datetime")]
    string DateTime { get; set; }
}
