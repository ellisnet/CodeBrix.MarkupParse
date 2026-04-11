using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the video HTML element.
/// </summary>
[DomName("HTMLVideoElement")]
public interface IHtmlVideoElement : IHtmlMediaElement
{
    /// <summary>
    /// Gets or sets the displayed width of the video element.
    /// </summary>
    [DomName("width")]
    int DisplayWidth { get; set; }

    /// <summary>
    /// Gets or sets the displayed height of the video element.
    /// </summary>
    [DomName("height")]
    int DisplayHeight { get; set; }

    /// <summary>
    /// Gets the width of the video.
    /// </summary>
    [DomName("videoWidth")]
    int OriginalWidth { get; }

    /// <summary>
    /// Gets the height of the video.
    /// </summary>
    [DomName("videoHeight")]
    int OriginalHeight { get; }

    /// <summary>
    /// Gets or sets the URL to a preview image.
    /// </summary>
    [DomName("poster")]
    string Poster { get; set; }
}
