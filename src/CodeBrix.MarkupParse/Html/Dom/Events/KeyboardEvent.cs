using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the event arguments for a keyboard event.
/// </summary>
[DomName("KeyboardEvent")]
public class KeyboardEvent : UiEvent
{
    #region Fields

    private string _modifiers;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new event.
    /// </summary>
    public KeyboardEvent()
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
    /// <param name="key">Sets the key that is currently pressed.</param>
    /// <param name="location">Sets the position of the originating keyboard.</param>
    /// <param name="modifiersList">A list with keyboard modifiers that have been pressed.</param>
    /// <param name="repeat">Sets if the key has been pressed again.</param>
    [DomConstructor]
    [DomInitDict(offset: 1, optional: true)]
    public KeyboardEvent(string type, bool bubbles = false, bool cancelable = false, IWindow view = null, int detail = 0, string key = null, KeyboardLocation location = KeyboardLocation.Standard, string modifiersList = null, bool repeat = false)
    {
        Init(type, bubbles, cancelable, view, detail, key ?? string.Empty, location, modifiersList ?? string.Empty, repeat);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets string representation of the pressed key.
    /// </summary>
    [DomName("key")]
    public string Key
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the location of the keyboard that initiated the event.
    /// </summary>
    [DomName("location")]
    public KeyboardLocation Location
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets if the control key is pressed.
    /// </summary>
    [DomName("ctrlKey")]
    public bool IsCtrlPressed => _modifiers.IsCtrlPressed();

    /// <summary>
    /// Gets if the shift key is pressed.
    /// </summary>
    [DomName("shiftKey")]
    public bool IsShiftPressed => _modifiers.IsShiftPressed();

    /// <summary>
    /// Gets if the alt key is pressed.
    /// </summary>
    [DomName("altKey")]
    public bool IsAltPressed => _modifiers.IsAltPressed();

    /// <summary>
    /// Gets if the meta key is pressed.
    /// </summary>
    [DomName("metaKey")]
    public bool IsMetaPressed => _modifiers.IsMetaPressed();

    /// <summary>
    /// Gets if the key press was repeated.
    /// </summary>
    [DomName("repeat")]
    public bool IsRepeated
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
        return _modifiers!.ContainsKey(key);
    }

    /// <summary>
    /// Gets the locale of the keyboard.
    /// </summary>
    [DomName("locale")]
    public string Locale => IsTrusted ? string.Empty : null;

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the keyboard event.
    /// </summary>
    /// <param name="type">The type of event.</param>
    /// <param name="bubbles">Determines if the event bubbles.</param>
    /// <param name="cancelable">Determines if the event is cancelable.</param>
    /// <param name="view">Sets the associated view for the UI event.</param>
    /// <param name="detail">Sets the detail id for the UI event.</param>
    /// <param name="key">Sets the key that is currently pressed.</param>
    /// <param name="location">Sets the position of the originating keyboard.</param>
    /// <param name="modifiersList">A list with keyboard modifiers that have been pressed.</param>
    /// <param name="repeat">Sets if the key has been pressed again.</param>
    [DomName("initKeyboardEvent")]
    [MemberNotNull(nameof(Key), nameof(Location), nameof(_modifiers))]
    public void Init(string type, bool bubbles, bool cancelable, IWindow view, int detail, string key, KeyboardLocation location, string modifiersList, bool repeat)
    {
        Init(type, bubbles, cancelable, view, detail);
        Key = key;
        Location = location;
        IsRepeated = repeat;
        _modifiers = modifiersList;
    }

    #endregion
}
