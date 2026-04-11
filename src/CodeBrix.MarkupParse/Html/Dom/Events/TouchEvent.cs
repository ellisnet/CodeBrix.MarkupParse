using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the event arguments for a touch event.
/// </summary>
[DomName("TouchEvent")]
public class TouchEvent : UiEvent
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public TouchEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="view">Sets the associated view for the UI event.</param>
    /// <param name="detail">Sets the detail id for the UIevent.</param>
    /// <param name="touches">The list of active touches.</param>
    /// <param name="targetTouches">The list of target-active toches.</param>
    /// <param name="changedTouches">The list of changed touches.</param>
    /// <param name="ctrlKey">Sets if the control key was pressed.</param>
    /// <param name="altKey">Sets if the alt key was pressed.</param>
    /// <param name="shiftKey">Sets if the shift key was pressed.</param>
    /// <param name="metaKey">Sets if the meta key was pressed.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public TouchEvent(string type, bool bubbles = false, bool cancelable = false, IWindow view = null, int detail = 0, ITouchList touches = null, ITouchList targetTouches = null, ITouchList changedTouches = null, bool ctrlKey = false, bool altKey = false, bool shiftKey = false, bool metaKey = false)
    {
        Init(type, bubbles, cancelable, view, detail);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets a list with all active touch points.
    /// </summary>
    [DomName("touches")]
    public ITouchList Touches
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets a list with touch points over the target.
    /// </summary>
    [DomName("targetTouches")]
    public ITouchList TargetTouches
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets a list with changed touch points.
    /// </summary>
    [DomName("changedTouches")]
    public ITouchList ChangedTouches
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets if the alt key is pressed.
    /// </summary>
    [DomName("altKey")]
    public bool IsAltPressed
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets if the meta key is pressed.
    /// </summary>
    [DomName("metaKey")]
    public bool IsMetaPressed
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets if the control key is pressed.
    /// </summary>
    [DomName("ctrlKey")]
    public bool IsCtrlPressed
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets if the shift key is pressed.
    /// </summary>
    [DomName("shiftKey")]
    public bool IsShiftPressed
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the focus event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="view">Sets the associated view for the UI event.</param>
    /// <param name="detail">Sets the detail id for the UIevent.</param>
    /// <param name="touches">The list of active touches.</param>
    /// <param name="targetTouches">The list of target-active toches.</param>
    /// <param name="changedTouches">The list of changed touches.</param>
    /// <param name="ctrlKey">Sets if the control key was pressed.</param>
    /// <param name="altKey">Sets if the alt key was pressed.</param>
    /// <param name="shiftKey">Sets if the shift key was pressed.</param>
    /// <param name="metaKey">Sets if the meta key was pressed.</param>
    [DomName("initTouchEvent")]
    public void Init(string type, bool bubbles, bool cancelable, IWindow view, int detail, ITouchList touches, ITouchList targetTouches, ITouchList changedTouches, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey)
    {
        Init(type, bubbles, cancelable, view, detail);
        Touches = touches;
        TargetTouches = targetTouches;
        ChangedTouches = changedTouches;
        IsCtrlPressed = ctrlKey;
        IsShiftPressed = shiftKey;
        IsMetaPressed = metaKey;
        IsAltPressed = altKey;
    }

    #endregion
}
