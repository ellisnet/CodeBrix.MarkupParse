using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents an video track.
/// </summary>
[DomName("VideoTrack")]
public interface IVideoTrack
{
    /// <summary>
    /// Gets the id of the video track.
    /// </summary>
    [DomName("id")]
    string Id { get; }

    /// <summary>
    /// Gets the kind of video track.
    /// </summary>
    [DomName("kind")]
    string Kind { get; }

    /// <summary>
    /// Gets the label of the track.
    /// </summary>
    [DomName("label")]
    string Label { get; }

    /// <summary>
    /// Gets the language of the track.
    /// </summary>
    [DomName("language")]
    string Language { get; }

    /// <summary>
    /// Gets or sets if the track is selected.
    /// </summary>
    [DomName("selected")]
    bool IsSelected { get; set; }
}
