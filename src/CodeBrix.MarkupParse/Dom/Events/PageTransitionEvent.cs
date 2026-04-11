using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom.Events; //Was previously: namespace AngleSharp.Dom.Events

/// <summary>
/// Represents a page transition event argument.
/// </summary>
[DomName("PageTransitionEvent")]
public class PageTransitionEvent : Event
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public PageTransitionEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="persisted">Indicates if a webpage is loading from a cache.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public PageTransitionEvent(string type, bool bubbles = false, bool cancelable = false, bool persisted = false)
    {
        Init(type, bubbles, cancelable, persisted);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets if a webpage is loading from a cache..
    /// </summary>
    [DomName("persisted")]
    public bool IsPersisted
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the event.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="persisted">Indicates if a webpage is loading from a cache.</param>
    [DomName("initPageTransitionEvent")]
    public void Init(string type, bool bubbles, bool cancelable, bool persisted)
    {
        Init(type, bubbles, cancelable);
        IsPersisted = persisted;
    }

    #endregion
}
