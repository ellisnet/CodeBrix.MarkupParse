using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the html HTML element.
/// </summary>
[DomName("HTMLHtmlElement")]
public interface IHtmlHtmlElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the value of the manifest attribute.
    /// </summary>
    [DomName("manifest")]
    string Manifest { get; set; }
}
