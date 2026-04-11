using System;

namespace CodeBrix.MarkupParse.Html; //Was previously: namespace AngleSharp.Html

/// <summary>
/// The collection of (known / used) input type names.
/// </summary>
public static class InputTypeNames
{
    /// <summary>
    /// The input will be hidden.
    /// </summary>
    public static readonly string Hidden = "hidden";

    /// <summary>
    /// A standard (1-line) text input.
    /// </summary>
    public static readonly string Text = "text";

    /// <summary>
    /// A search input.
    /// </summary>
    public static readonly string Search = "search";

    /// <summary>
    /// A telephone number input.
    /// </summary>
    public static readonly string Tel = "tel";

    /// <summary>
    /// An URL input field.
    /// </summary>
    public static readonly string Url = "url";

    /// <summary>
    /// An email input field.
    /// </summary>
    public static readonly string Email = "email";

    /// <summary>
    /// A password input field.
    /// </summary>
    public static readonly string Password = "password";

    /// <summary>
    /// A datetime input field.
    /// </summary>
    public static readonly string Datetime = "datetime";

    /// <summary>
    /// A datetime-local input field.
    /// </summary>
    public static readonly string DatetimeLocal = "datetime-local";

    /// <summary>
    /// A date input field.
    /// </summary>
    public static readonly string Date = "date";

    /// <summary>
    /// A month picker input field.
    /// </summary>
    public static readonly string Month = "month";

    /// <summary>
    /// A week picker input field.
    /// </summary>
    public static readonly string Week = "week";

    /// <summary>
    /// A time picker input field.
    /// </summary>
    public static readonly string Time = "time";

    /// <summary>
    /// A number input field.
    /// </summary>
    public static readonly string Number = "number";

    /// <summary>
    /// A range picker.
    /// </summary>
    public static readonly string Range = "range";

    /// <summary>
    /// A color picker input field.
    /// </summary>
    public static readonly string Color = "color";

    /// <summary>
    /// A checkbox.
    /// </summary>
    public static readonly string Checkbox = "checkbox";

    /// <summary>
    /// A radio box.
    /// </summary>
    public static readonly string Radio = "radio";

    /// <summary>
    /// A file upload box.
    /// </summary>
    public static readonly string File = "file";

    /// <summary>
    /// A submit button.
    /// </summary>
    public static readonly string Submit = "submit";

    /// <summary>
    /// An image input box.
    /// </summary>
    public static readonly string Image = "image";

    /// <summary>
    /// A reset form button.
    /// </summary>
    public static readonly string Reset = "reset";

    /// <summary>
    /// A simple button.
    /// </summary>
    public static readonly string Button = "button";

    /// <summary>
    /// A select-multiple select box.
    /// </summary>
    public static readonly string SelectMultiple = "select-multiple";

    /// <summary>
    /// A select-one select box.
    /// </summary>
    public static readonly string SelectOne = "select-one";
}
