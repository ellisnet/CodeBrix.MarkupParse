using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents an audio track.
/// </summary>
[DomName("AudioTrack")]
public interface IAudioTrack
{
    /// <summary>
    /// Gets the id of the audio track.
    /// </summary>
    [DomName("id")]
    string Id { get; }

    /// <summary>
    /// Gets the kind of audio track.
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
    /// Gets or sets if the track is enabled.
    /// </summary>
    [DomName("enabled")]
    bool IsEnabled { get; set; }
}
