using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom.Events;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents a track that provides an additional track information.
/// </summary>
[DomName("TrackEvent")]
public class TrackEvent : Event
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public TrackEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="track">The track object.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public TrackEvent(string type, bool bubbles = false, bool cancelable = false, object track = null)
    {
        Init(type, bubbles, cancelable, track);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the assigned track object, if any.
    /// </summary>
    [DomName("track")]
    public object Track
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the mouse event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="track">The track object.</param>
    [DomName("initTrackEvent")]
    public void Init(string type, bool bubbles, bool cancelable, object track)
    {
        Init(type, bubbles, cancelable);
        Track = track;
    }

    #endregion
}
