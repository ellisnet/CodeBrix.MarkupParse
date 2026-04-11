using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the data HTML element.
/// </summary>
[DomName("HTMLDataElement")]
public interface IHtmlDataElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the machine readable value.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }
}
