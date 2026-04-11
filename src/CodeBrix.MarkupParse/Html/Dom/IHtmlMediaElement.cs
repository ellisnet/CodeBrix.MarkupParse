using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Media.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base for all HTML media elements.
/// </summary>
[DomName("HTMLMediaElement")]
public interface IHtmlMediaElement : IHtmlElement, IMediaController, ILoadableElement
{
    /// <summary>
    /// Gets or sets the media source.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the cross-origin attribute.
    /// </summary>
    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    /// <summary>
    /// Gets or sets the preload attribute.
    /// </summary>
    [DomName("preload")]
    string Preload { get; set; }

    /// <summary>
    /// Gets or sets the id of the assigned media group.
    /// </summary>
    [DomName("mediaGroup")]
    string MediaGroup { get; set; }

    /// <summary>
    /// Gets the current network state.
    /// </summary>
    [DomName("networkState")]
    MediaNetworkState NetworkState { get; }

    /// <summary>
    /// Gets if seeking is currently active.
    /// </summary>
    [DomName("seeking")]
    bool IsSeeking { get; }

    /// <summary>
    /// Gets the current media source.
    /// </summary>
    [DomName("currentSrc")]
    string CurrentSource { get; }

    /// <summary>
    /// Gets the current media error, if any.
    /// </summary>
    [DomName("error")]
    IMediaError MediaError { get; }

    /// <summary>
    /// Gets the current media's controller, if any.
    /// </summary>
    [DomName("controller")]
    IMediaController Controller { get; }

    /// <summary>
    /// Gets if the media has ended.
    /// </summary>
    [DomName("ended")]
    bool IsEnded { get; }

    /// <summary>
    /// Gets or sets if the media is automatically played.
    /// </summary>
    [DomName("autoplay")]
    bool IsAutoplay { get; set; }

    /// <summary>
    /// Gets or sets if the media should loop.
    /// </summary>
    [DomName("loop")]
    bool IsLoop { get; set; }

    /// <summary>
    /// Gets or sets if the controls should be shown to the user.
    /// </summary>
    [DomName("controls")]
    bool IsShowingControls { get; set; }

    /// <summary>
    /// Gets or sets if the media is muted by default.
    /// </summary>
    [DomName("defaultMuted")]
    bool IsDefaultMuted { get; set; }

    /// <summary>
    /// Loads the currently assigned media source.
    /// </summary>
    [DomName("load")]
    void Load();

    /// <summary>
    /// Checks if the given type can be played.
    /// </summary>
    /// <param name="type">The type to check for.</param>
    /// <returns>One of the following values: probably, maybe or an empty string.</returns>
    [DomName("canPlayType")]
    string CanPlayType(string type);

    /// <summary>
    /// Gets the datetime when the download started.
    /// </summary>
    [DomName("startDate")]
    DateTime StartDate { get; }

    /// <summary>
    /// Gets a list of contained audio tracks.
    /// </summary>
    [DomName("audioTracks")]
    IAudioTrackList AudioTracks { get; }

    /// <summary>
    /// Gets a list of contained video tracks.
    /// </summary>
    [DomName("videoTracks")]
    IVideoTrackList VideoTracks { get; }

    /// <summary>
    /// Gets a list of contained text tracks.
    /// </summary>
    [DomName("textTracks")]
    ITextTrackList TextTracks { get; }

    /// <summary>
    /// Adds a new text track to the media element.
    /// </summary>
    /// <param name="kind">The kind of text track to create.</param>
    /// <param name="label">The optional label of the track.</param>
    /// <param name="language">The optional language of the track.</param>
    /// <returns>The freshly created text track.</returns>
    [DomName("addTextTrack")]
    ITextTrack AddTextTrack(string kind, string label = null, string language = null);
}
