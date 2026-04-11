using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the textarea HTML element.
/// </summary>
[DomName("HTMLTextAreaElement")]
public interface IHtmlTextAreaElement : IHtmlElement, IValidation
{
    /// <summary>
    /// Gets or sets the autofocus HTML attribute, which indicates whether the
    /// control should have input focus when the page loads.
    /// </summary>
    [DomName("autofocus")]
    bool Autofocus { get; set; }

    /// <summary>
    /// Gets or sets if the textarea is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets the associated HTML form element.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets the list of assigned labels.
    /// </summary>
    [DomName("labels")]
    INodeList Labels { get; }

    /// <summary>
    /// Gets or sets the name of the element.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets the type (textarea).
    /// </summary>
    [DomName("type")]
    string Type { get; }

    /// <summary>
    /// Gets or sets if the field is required.
    /// </summary>
    [DomName("required")]
    bool IsRequired { get; set; }

    /// <summary>
    /// Gets or sets if the field is read-only.
    /// </summary>
    [DomName("readOnly")]
    bool IsReadOnly { get; set; }

    /// <summary>
    /// Gets or sets the default value.
    /// </summary>
    [DomName("defaultValue")]
    string DefaultValue { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }

    /// <summary>
    /// Gets or sets the wrap HTML attribute, indicating how the control wraps text.
    /// </summary>
    [DomName("wrap")]
    string Wrap { get; set; }

    /// <summary>
    /// Gets the codepoint length of the control's value.
    /// </summary>
    [DomName("textLength")]
    int TextLength { get; }

    /// <summary>
    /// Gets or sets the rows HTML attribute, indicating
    /// the number of visible text lines for the control.
    /// </summary>
    [DomName("rows")]
    int Rows { get; set; }

    /// <summary>
    /// Gets or sets the cols HTML attribute, indicating
    /// the visible width of the text area.
    /// </summary>
    [DomName("cols")]
    int Columns { get; set; }

    /// <summary>
    /// Gets or sets the maxlength HTML attribute, indicating
    /// the maximum number of characters the user can enter.
    /// This constraint is evaluated only when the value changes.
    /// </summary>
    [DomName("maxLength")]
    int MaxLength { get; set; }
    
    /// <summary>
    /// Gets or sets the placeholder HTML attribute, containing a hint to
    /// the user about what to enter in the control.
    /// </summary>
    [DomName("placeholder")]
    string Placeholder { get; set; }
    
    /// <summary>
    /// Gets the direction in which selection occurred. This is "forward" if
    /// selection was performed in the start-to-end direction of the current
    /// locale, or "backward" for the opposite direction.
    /// </summary>
    [DomName("selectionDirection")]
    string SelectionDirection { get; }

    /// <summary>
    /// Gets or sets the directionality of the form element.
    /// </summary>
    [DomName("dirName")]
    string DirectionName { get; set; }
    
    /// <summary>
    /// Gets or sets the index of the beginning of selected text.
    /// If no text is selected, contains the index of the character
    /// that follows the input cursor. On being set, the control behaves
    /// as if setSelectionRange() had been called with this as the first
    /// argument, and selectionEnd as the second argument.
    /// </summary>
    [DomName("selectionStart")]
    int SelectionStart { get; set; }
    
    /// <summary>
    /// Gets or sets the index of the end of selected text. If no text
    /// is selected, contains the index of the character that follows
    /// the input cursor. On being set, the control behaves as if
    /// setSelectionRange() had been called with this as the second
    /// argument, and selectionStart as the first argument.
    /// </summary>
    [DomName("selectionEnd")]
    int SelectionEnd { get; set; }
    
    /// <summary>
    /// Selects the contents of the textarea.
    /// </summary>
    [DomName("select")]
    void SelectAll();
    
    /// <summary>
    /// Selects a range of text, and sets selectionStart and selectionEnd.
    /// If either argument is greater than the length of the value, it is treated
    /// as pointing to the end of the value. If end is less than start, then
    /// both are treated as the value of end.
    /// </summary>
    /// <param name="selectionStart">The start of the selection.</param>
    /// <param name="selectionEnd">The end of the selection.</param>
    /// <param name="selectionDirection">Optional: The direction of the selection.</param>
    [DomName("setSelectionRange")]
    void Select(int selectionStart, int selectionEnd, string selectionDirection = null);
}
