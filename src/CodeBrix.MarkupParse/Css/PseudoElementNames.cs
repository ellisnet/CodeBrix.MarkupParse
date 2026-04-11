using System;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// The collection of (known / used) selector pseudo element names.
/// </summary>
public static class PseudoElementNames
{
    /// <summary>
    /// The before pseudo element.
    /// </summary>
    public static readonly string Before = "before";

    /// <summary>
    /// The after pseudo element.
    /// </summary>
    public static readonly string After = "after";

    /// <summary>
    /// The slotted pseudo element.
    /// </summary>
    public static readonly string Slotted = "slotted";

    /// <summary>
    /// The selection pseudo element.
    /// </summary>
    public static readonly string Selection = "selection";

    /// <summary>
    /// The first-line pseudo element.
    /// </summary>
    public static readonly string FirstLine = "first-line";

    /// <summary>
    /// The first-letter pseudo element.
    /// </summary>
    public static readonly string FirstLetter = "first-letter";

    /// <summary>
    /// The footnote-call pseudo element.
    /// </summary>
    public static readonly string FootnoteCall = "footnote-call";

    /// <summary>
    /// The footnote-marker pseudo element.
    /// </summary>
    public static readonly string FootnoteMarker = "footnote-marker";

    /// <summary>
    /// The content pseudo element.
    /// </summary>
    public static readonly string Content = "content";

    /// <summary>
    /// The checkmark pseudo element.
    /// </summary>
    public static readonly string Checkmark = "checkmark";

    /// <summary>
    /// The picker-icon pseudo element.
    /// </summary>
    public static readonly string PickerIcon = "picker-icon";

    /// <summary>
    /// The picker pseudo element function.
    /// </summary>
    public static readonly string Picker = "picker";

    /// <summary>
    /// The separating double-colon.
    /// </summary>
    public static readonly string Separator = "::";
}
