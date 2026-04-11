using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents a list of text tracks.
/// </summary>
[DomName("TextTrackList")]
public interface ITextTrackList : IEventTarget, IEnumerable<ITextTrack>
{
    /// <summary>
    /// Gets the number of tracks.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets the track at the given index.
    /// </summary>
    /// <param name="index">The 0-based track index.</param>
    /// <returns>The track at the position.</returns>
    [DomAccessor(Accessors.Getter)]
    ITextTrack this[int index] { get; }

    /// <summary>
    /// Event triggered after adding a track.
    /// </summary>
    [DomName("onaddtrack")]
    event DomEventHandler TrackAdded;

    /// <summary>
    /// Event triggered after removing a track.
    /// </summary>
    [DomName("onremovetrack")]
    event DomEventHandler TrackRemoved;
}
