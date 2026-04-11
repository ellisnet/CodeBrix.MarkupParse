using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the image HTML element.
/// </summary>
[DomName("HTMLImageElement")]
public interface IHtmlImageElement : IHtmlElement, ILoadableElement
{
    /// <summary>
    /// Gets or sets the alternative text.
    /// </summary>
    [DomName("alt")]
    string AlternativeText { get; set; }

    /// <summary>
    /// Gets the actual used image source.
    /// </summary>
    [DomName("currentSrc")]
    string ActualSource { get; }

    /// <summary>
    /// Gets or sets the image source.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the image candidates for higher density images.
    /// </summary>
    [DomName("srcset")]
    string SourceSet { get; set; }

    /// <summary>
    /// Gets or sets the sizes to responsively.
    /// </summary>
    [DomName("sizes")]
    string Sizes { get; set; }

    /// <summary>
    /// Gets or sets the cross-origin attribute.
    /// </summary>
    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    /// <summary>
    /// Gets or sets the usemap attribute, which indicates that the image
    /// has an associated image map.
    /// </summary>
    [DomName("useMap")]
    string UseMap { get; set; }

    /// <summary>
    /// Gets or sets if the image element is a map. The attribute must not
    /// be specified on an element that does not have an ancestor a
    /// element with an href attribute.
    /// </summary>
    [DomName("isMap")]
    bool IsMap { get; set; }

    /// <summary>
    /// Gets or sets the displayed width of the image element.
    /// </summary>
    [DomName("width")]
    int DisplayWidth { get; set; }

    /// <summary>
    /// Gets or sets the displayed width of the image element.
    /// </summary>
    [DomName("height")]
    int DisplayHeight { get; set; }

    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    [DomName("naturalWidth")]
    int OriginalWidth { get; }

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    [DomName("naturalHeight")]
    int OriginalHeight { get; }

    /// <summary>
    /// Gets if the image is completely available.
    /// </summary>
    [DomName("complete")]
    bool IsCompleted { get; }
}
