using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The embed HTML element.
/// </summary>
[DomName("HTMLEmbedElement")]
public interface IHtmlEmbedElement : IHtmlElement, ILoadableElement
{
    /// <summary>
    /// Gets or sets the source of the object to embed.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the type of the embedded object.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets the display width of the object.
    /// </summary>
    [DomName("width")]
    string DisplayWidth { get; set; }

    /// <summary>
    /// Gets or sets the display height of the object.
    /// </summary>
    [DomName("height")]
    string DisplayHeight { get; set; }
}
