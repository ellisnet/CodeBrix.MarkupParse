using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the event arguments for an input event.
/// </summary>
[DomName("InputEvent")]
public class InputEvent : Event
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public InputEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="data">Sets the data for the input event.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public InputEvent(string type, bool bubbles = false, bool cancelable = false, string data = null)
    {
        Init(type, bubbles, cancelable, data ?? string.Empty);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the data that has been entered.
    /// </summary>
    [DomName("data")]
    public string Data
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the input event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="data">Sets the data for the input event.</param>
    [DomName("initInputEvent")]
    public void Init(string type, bool bubbles, bool cancelable, string data)
    {
        Init(type, bubbles, cancelable);
        Data = data;
    }

    #endregion
}
