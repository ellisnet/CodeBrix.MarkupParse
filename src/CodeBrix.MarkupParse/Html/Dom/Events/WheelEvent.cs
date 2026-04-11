using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the event args for a mouse wheel event.
/// </summary>
[DomName("WheelEvent")]
public class WheelEvent : MouseEvent
{
    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public WheelEvent()
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
    /// <param name="button">Sets which button has been pressed.</param>
    /// <param name="target">The target of the mouse event.</param>
    /// <param name="modifiersList">A list with keyboard modifiers that have been pressed.</param>
    /// <param name="deltaX">The mouse wheel delta in X direction.</param>
    /// <param name="deltaY">The mouse wheel delta in Y direction.</param>
    /// <param name="deltaZ">The mouse wheel delta in Z direction.</param>
    /// <param name="deltaMode">The delta mode for the wheel event.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public WheelEvent(string type, bool bubbles = false, bool cancelable = false, IWindow view = null, int detail = 0, int screenX = 0, int screenY = 0, int clientX = 0, int clientY = 0, MouseButton button = MouseButton.Primary, IEventTarget target = null, string modifiersList = null, double deltaX = 0.0, double deltaY = 0.0, double deltaZ = 0.0, WheelMode deltaMode = WheelMode.Pixel)
    {
        Init(type, bubbles, cancelable, view, detail, screenX, screenY, clientX, clientY, button, target, modifiersList ?? string.Empty, deltaX, deltaY, deltaZ, deltaMode);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the mouse wheel delta X.
    /// </summary>
    [DomName("deltaX")]
    public double DeltaX
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the mouse wheel delta Y.
    /// </summary>
    [DomName("deltaY")]
    public double DeltaY
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the mouse wheel delta Z.
    /// </summary>
    [DomName("deltaZ")]
    public double DeltaZ
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the mouse wheel delta mode.
    /// </summary>
    [DomName("deltaMode")]
    public WheelMode DeltaMode
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the mouse wheel event.
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
    /// <param name="button">Sets which button has been pressed.</param>
    /// <param name="target">The target of the mouse event.</param>
    /// <param name="modifiersList">A list with keyboard modifiers that have been pressed.</param>
    /// <param name="deltaX">The mouse wheel delta in X direction.</param>
    /// <param name="deltaY">The mouse wheel delta in Y direction.</param>
    /// <param name="deltaZ">The mouse wheel delta in Z direction.</param>
    /// <param name="deltaMode">The delta mode for the wheel event.</param>
    [DomName("initWheelEvent")]
    public void Init(string type, bool bubbles, bool cancelable, IWindow view, int detail, int screenX, int screenY, int clientX, int clientY, MouseButton button, IEventTarget target, string modifiersList, double deltaX, double deltaY, double deltaZ, WheelMode deltaMode)
    {
        Init(type, bubbles, cancelable, view, detail, screenX, screenY, clientX, clientY, 
            modifiersList.IsCtrlPressed(), modifiersList.IsAltPressed(), modifiersList.IsShiftPressed(), modifiersList.IsMetaPressed(), button, target);
        DeltaX = deltaX;
        DeltaY = deltaY;
        DeltaZ = deltaZ;
        DeltaMode = deltaMode;
    }

    #endregion
}
