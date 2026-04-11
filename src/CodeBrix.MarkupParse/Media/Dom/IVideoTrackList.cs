using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents a list of video tracks.
/// </summary>
[DomName("VideoTrackList")]
public interface IVideoTrackList : IEventTarget, IEnumerable<IVideoTrack>
{
    /// <summary>
    /// Gets the number of tracks.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets the currently selected index.
    /// </summary>
    [DomName("selectedIndex")]
    int SelectedIndex { get; }

    /// <summary>
    /// Gets the track at the given index.
    /// </summary>
    /// <param name="index">The 0-based track index.</param>
    /// <returns>The track at the position.</returns>
    [DomAccessor(Accessors.Getter)]
    IVideoTrack this[int index] { get; }

    /// <summary>
    /// Gets the track with the specified id.
    /// </summary>
    /// <param name="id">The HTML id of the track.</param>
    /// <returns>The track with the given id, if any.</returns>
    [DomName("getTrackById")]
    IVideoTrack GetTrackById(string id);

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
