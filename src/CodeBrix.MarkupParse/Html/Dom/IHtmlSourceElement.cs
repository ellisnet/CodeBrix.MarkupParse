using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the source HTML element.
/// </summary>
[DomName("HTMLSourceElement")]
public interface IHtmlSourceElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the URL for a media resource. Is ignored when used for
    /// the picture element.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the URL of a picture element.
    /// </summary>
    [DomName("srcset")]
    string SourceSet { get; set; }

    /// <summary>
    /// Gets or sets the sizes if used in conjunction with a picture.
    /// </summary>
    [DomName("sizes")]
    string Sizes { get; set; }

    /// <summary>
    /// Gets or sets the type of the media source.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets the intended type of the media resource.
    /// </summary>
    [DomName("media")]
    string Media { get; set; }
}
