using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Browser.Dom.Events; //Was previously: namespace AngleSharp.Browser.Dom.Events

/// <summary>
/// The event that is published in case of a tracking
/// possibility (e.g., errors) coming from the dynamic DOM.
/// </summary>
public class TrackEvent : Event
{
    /// <summary>
    /// Creates a new event for a tracking request.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="error">The error to be transported.</param>
    public TrackEvent(string eventName, Exception error)
        : base(eventName)
    {
        Error = error;
    }

    /// <summary>
    /// Error to be transported.
    /// </summary>
    public Exception Error { get; }
}
