using CodeBrix.MarkupParse.Attributes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Dom.Events; //Was previously: namespace AngleSharp.Dom.Events

/// <summary>
/// Represents a custom event that provides an additional details property.
/// </summary>
[DomName("HashChangeEvent")]
public class HashChangedEvent : Event
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public HashChangedEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="oldURL">The previous URL.</param>
    /// <param name="newURL">The current URL.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public HashChangedEvent(string type, bool bubbles = false, bool cancelable = false, string oldURL = null, string newURL = null)
    {
        Init(type, bubbles, cancelable, oldURL ?? string.Empty, newURL ?? string.Empty);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the URL before the hash changed.
    /// </summary>
    [DomName("oldURL")]
    public string PreviousUrl
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the URL after the hash changed.
    /// </summary>
    [DomName("newURL")]
    public string CurrentUrl
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the hashchanged event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="previousUrl">The previous URL.</param>
    /// <param name="currentUrl">The current URL.</param>
    [DomName("initHashChangedEvent")]
    [MemberNotNull(nameof(PreviousUrl), nameof(CurrentUrl))]
    public void Init(string type, bool bubbles, bool cancelable, string previousUrl, string currentUrl)
    {
        Init(type, bubbles, cancelable);
        Stop();
        PreviousUrl = previousUrl;
        CurrentUrl = currentUrl;
    }

    #endregion
}
