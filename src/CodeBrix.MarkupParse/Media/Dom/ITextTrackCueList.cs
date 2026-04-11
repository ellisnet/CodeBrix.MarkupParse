using CodeBrix.MarkupParse.Attributes;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Contains a list of text cues.
/// </summary>
[DomName("TextTrackCueList")]
public interface ITextTrackCueList : IEnumerable<ITextTrackCue>
{
    /// <summary>
    /// Gets the number of cues.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets the cue at the given index.
    /// </summary>
    /// <param name="index">The 0-based cue index.</param>
    /// <returns>The cue at the position.</returns>
    ITextTrackCue this[int index] { get; }

    /// <summary>
    /// Gets the cue with the specified id.
    /// </summary>
    /// <param name="id">The HTML id of the cue.</param>
    /// <returns>The cue with the given id, if any.</returns>
    [DomName("getCueById")]
    IVideoTrack GetCueById(string id);
}
