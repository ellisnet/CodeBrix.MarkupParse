using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents a list of audio tracks.
/// </summary>
[DomName("AudioTrackList")]
public interface IAudioTrackList : IEventTarget, IEnumerable<IAudioTrack>
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
    IAudioTrack this[int index] { get; }

    /// <summary>
    /// Gets the track with the specified id.
    /// </summary>
    /// <param name="id">The HTML id of the track.</param>
    /// <returns>The track with the given id, if any.</returns>
    [DomName("getTrackById")]
    IAudioTrack GetTrackById(string id);

    /// <summary>
    /// Event triggered after changing contents.
    /// </summary>
    [DomName("onchange")]
    event DomEventHandler Changed;

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
