using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the command HTML element.
/// </summary>
[DomName("HTMLCommandElement")]
public interface IHtmlCommandElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the type of command.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets the assigned label.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }

    /// <summary>
    /// Gets or sets the icon of the command.
    /// </summary>
    [DomName("icon")]
    string Icon { get; set; }

    /// <summary>
    /// Gets or sets if the command is disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets if the command is checked.
    /// </summary>
    [DomName("checked")]
    bool IsChecked { get; set; }

    /// <summary>
    /// Gets or sets the id of the radio group of the command.
    /// </summary>
    [DomName("radiogroup")]
    string RadioGroup { get; set; }

    /// <summary>
    /// Gets the assigned element.
    /// </summary>
    [DomName("command")]
    IHtmlElement Command { get; }
}
