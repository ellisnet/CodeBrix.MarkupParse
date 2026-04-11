using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Information about a text track.
/// </summary>
[DomName("TextTrack")]
public interface ITextTrack : IEventTarget
{
    /// <summary>
    /// Gets the text track kind of the text track.
    /// </summary>
    [DomName("kind")]
    string Kind { get; }

    /// <summary>
    /// Gets the text track label of the text track.
    /// </summary>
    [DomName("label")]
    string Label { get; }

    /// <summary>
    /// Gets the text track language of the text track.
    /// </summary>
    [DomName("language")]
    string Language { get; }

    /// <summary>
    /// Gets or sets the mode of the text track.
    /// </summary>
    [DomName("mode")]
    TextTrackMode Mode { get; set; }

    /// <summary>
    /// Gets the available text cues.
    /// </summary>
    [DomName("cues")]
    ITextTrackCueList Cues { get; }

    /// <summary>
    /// Gets the active text cues.
    /// </summary>
    [DomName("activeCues")]
    ITextTrackCueList ActiveCues { get; }

    /// <summary>
    /// Adds another cue to the text track.
    /// </summary>
    /// <param name="cue">The cue to add.</param>
    [DomName("addCue")]
    void Add(ITextTrackCue cue);

    /// <summary>
    /// Removes a cue from the text track.
    /// </summary>
    /// <param name="cue">The cue that should be removed.</param>
    [DomName("removeCue")]
    void Remove(ITextTrackCue cue);

    /// <summary>
    /// Event triggered after a cue has changed.
    /// </summary>
    [DomName("oncuechange")]
    event DomEventHandler CueChanged;
}
