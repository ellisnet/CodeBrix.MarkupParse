using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the menuitem HTML element.
/// </summary>
[DomName("HTMLMenuItemElement")]
public interface IHtmlMenuItemElement : IHtmlElement
{
    /// <summary>
    /// Gets the assigned master command, if any.
    /// </summary>
    [DomName("command")]
    IHtmlElement Command { get; }

    /// <summary>
    /// Gets or sets the type of command.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets the user-visible label.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }

    /// <summary>
    /// Gets or sets the icon for the command.
    /// </summary>
    [DomName("icon")]
    string Icon { get; set; }

    /// <summary>
    /// Gets or sets if the menuitem element is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets if the menuitem element is checked or not.
    /// </summary>
    [DomName("checked")]
    bool IsChecked { get; set; }

    /// <summary>
    /// Gets or sets if the menuitem element is the default command.
    /// </summary>
    [DomName("default")]
    bool IsDefault { get; set; }

    /// <summary>
    /// Gets or sets the name of group of commands to
    /// treat as a radio button group.
    /// </summary>
    [DomName("radiogroup")]
    string RadioGroup { get; set; }
}
