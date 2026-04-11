using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a style HTML element.
/// </summary>
[DomName("HTMLStyleElement")]
public interface IHtmlStyleElement : IHtmlElement, ILinkStyle
{
    /// <summary>
    /// Gets or sets if the style is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets the use with one or more target media.
    /// </summary>
    [DomName("media")]
    string Media { get; set; }

    /// <summary>
    /// Gets or sets the content type of the style sheet language.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets if the style is scoped.
    /// </summary>
    [DomName("scoped")]
    bool IsScoped { get; set; }
}
