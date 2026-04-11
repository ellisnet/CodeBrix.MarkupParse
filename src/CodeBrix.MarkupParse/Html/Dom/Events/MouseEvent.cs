using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the event args for a mouse event.
/// </summary>
[DomName("MouseEvent")]
public class MouseEvent : UiEvent
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public MouseEvent()
    {
    }

    /// <summary>
    /// Creates a new event and initializes it.
    /// </summary>
    /// <param name="type">The type of the event.</param>
    /// <param name="bubbles">If the event is bubbling.</param>
    /// <param name="cancelable">If the event is cancelable.</param>
    /// <param name="view">Sets the associated view for the UI event.</param>
    /// <param name="detail">Sets the detail id for the UI event.</param>
    /// <param name="screenX">Sets the screen X coordinate.</param>
    /// <param name="screenY">Sets the screen Y coordinate.</param>
    /// <param name="clientX">Sets the client X coordinate.</param>
    /// <param name="clientY">Sets the client Y coordinate.</param>
    /// <param name="ctrlKey">Sets if the control key was pressed.</param>
    /// <param name="altKey">Sets if the alt key was pressed.</param>
    /// <param name="shiftKey">Sets if the shift key was pressed.</param>
    /// <param name="metaKey">Sets if the meta key was pressed.</param>
    /// <param name="button">Sets which button has been pressed.</param>
    /// <param name="relatedTarget">The target of the mouse event.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public MouseEvent(string type, bool bubbles = false, bool cancelable = false, IWindow view = null, int detail = 0, int screenX = 0, int screenY = 0, int clientX = 0, int clientY = 0, bool ctrlKey = false, bool altKey = false, bool shiftKey = false, bool metaKey = false, MouseButton button = MouseButton.Primary, IEventTarget relatedTarget = null)
    {
        Init(type, bubbles, cancelable, view, detail, screenX, screenY, clientX, clientY, ctrlKey, altKey, shiftKey, metaKey, button, relatedTarget);
    }

    #endregion

    #region Properties 

    /// <summary>
    /// Gets the screen X coordinates.
    /// </summary>
    [DomName("screenX")]
    public int ScreenX
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the screen Y coordinates.
    /// </summary>
    [DomName("screenY")]
    public int ScreenY
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the client X coordinates.
    /// </summary>
    [DomName("clientX")]
    public int ClientX
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the client Y coordinates.
    /// </summary>
    [DomName("clientY")]
    public int ClientY
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
    /// Gets which button has been pressed.
    /// </summary>
    [DomName("button")]
    public MouseButton Button
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the currently pressed buttons.
    /// </summary>
    [DomName("buttons")]
    public MouseButtons Buttons
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the target of the mouse event.
    /// </summary>
    [DomName("relatedTarget")]
    public IEventTarget Target
    {
        get;
        private set;
    }

    /// <summary>
    /// Returns the current state of the specified modifier key.
    /// </summary>
    /// <param name="key">The modifier key to lookup.</param>
    /// <returns>True if the key is currently pressed, otherwise false.</returns>
    [DomName("getModifierState")]
    public bool GetModifierState(string key)
    {
        return false;//TODO
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the mouse event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="view">Sets the associated view for the UI event.</param>
    /// <param name="detail">Sets the detail id for the UIevent.</param>
    /// <param name="screenX">Sets the screen X coordinate.</param>
    /// <param name="screenY">Sets the screen Y coordinate.</param>
    /// <param name="clientX">Sets the client X coordinate.</param>
    /// <param name="clientY">Sets the client Y coordinate.</param>
    /// <param name="ctrlKey">Sets if the control key was pressed.</param>
    /// <param name="altKey">Sets if the alt key was pressed.</param>
    /// <param name="shiftKey">Sets if the shift key was pressed.</param>
    /// <param name="metaKey">Sets if the meta key was pressed.</param>
    /// <param name="button">Sets which button has been pressed.</param>
    /// <param name="target">The target of the mouse event.</param>
    [DomName("initMouseEvent")]
    public void Init(string type, bool bubbles, bool cancelable, IWindow view, int detail, int screenX, int screenY, int clientX, int clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, MouseButton button, IEventTarget target)
    {
        Init(type, bubbles, cancelable, view, detail);
        ScreenX = screenX;
        ScreenY = screenY;
        ClientX = clientX;
        ClientY = clientY;
        IsCtrlPressed = ctrlKey;
        IsMetaPressed = metaKey;
        IsShiftPressed = shiftKey;
        IsAltPressed = altKey;
        Button = button;
        Target = target;
    }

    #endregion
}
