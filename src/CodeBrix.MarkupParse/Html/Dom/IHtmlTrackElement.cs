using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Media.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the track HTML element.
/// </summary>
[DomName("HTMLTrackElement")]
public interface IHtmlTrackElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the kind of the track.
    /// </summary>
    [DomName("kind")]
    string Kind { get; set; }

    /// <summary>
    /// Gets or sets the media source.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the language of the source.
    /// </summary>
    [DomName("srclang")]
    string SourceLanguage { get; set; }

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }

    /// <summary>
    /// Gets or sets if given track is the default track.
    /// </summary>
    [DomName("default")]
    bool IsDefault { get; set; }

    /// <summary>
    /// Gets the ready state of the given track.
    /// </summary>
    [DomName("readyState")]
    TrackReadyState ReadyState { get; }

    /// <summary>
    /// Gets the associated text track.
    /// </summary>
    [DomName("track")]
    ITextTrack Track { get; }
}
