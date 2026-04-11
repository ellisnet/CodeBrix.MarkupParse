using CodeBrix.MarkupParse.Attributes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Dom.Events; //Was previously: namespace AngleSharp.Dom.Events

/// <summary>
/// Represents the event arguments when receiving a message.
/// </summary>
[DomName("MessageEvent")]
public class MessageEvent : Event
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public MessageEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="data">Sets the data for the message event.</param>
    /// <param name="origin">Sets the origin who send the message.</param>
    /// <param name="lastEventId">Sets the id of the last event.</param>
    /// <param name="source">Sets the source window of the message.</param>
    /// <param name="ports">The message ports to include.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public MessageEvent(string type, bool bubbles = false, bool cancelable = false, object data = null, string origin = null, string lastEventId = null, IWindow source = null, params IMessagePort[] ports)
    {
        Init(type, bubbles, cancelable, data, origin ?? string.Empty, lastEventId ?? string.Empty, source, ports);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the data that is carried by the message.
    /// </summary>
    [DomName("data")]
    public object Data
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the origin of the message.
    /// </summary>
    [DomName("origin")]
    public string Origin
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the id of the last event.
    /// </summary>
    [DomName("lastEventId")]
    public string LastEventId
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the source of the message.
    /// </summary>
    [DomName("source")]
    public IWindow Source
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the used message ports.
    /// </summary>
    [DomName("ports")]
    public IMessagePort[] Ports
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the message event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="data">Sets the data for the message event.</param>
    /// <param name="origin">Sets the origin who send the message.</param>
    /// <param name="lastEventId">Sets the id of the last event.</param>
    /// <param name="source">Sets the source window of the message.</param>
    /// <param name="ports">The message ports to include.</param>
    [DomName("initMessageEvent")]
    [MemberNotNull(nameof(Origin), nameof(LastEventId), nameof(Ports))]
    public void Init(string type, bool bubbles, bool cancelable, object data, string origin, string lastEventId, IWindow source, params IMessagePort[] ports)
    {
        Init(type, bubbles, cancelable);
        Data = data;
        Origin = origin;
        LastEventId = lastEventId;
        Source = source;
        Ports = ports;
    }

    #endregion
}
