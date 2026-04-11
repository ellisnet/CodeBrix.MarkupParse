using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the option HTML element.
/// </summary>
[DomName("HTMLOptionElement")]
public interface IHtmlOptionElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets if the option is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets the associated HTML form element.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    [DomName("label")]
    string Label { get; set; }

    /// <summary>
    /// Gets or sets if the option is selected by default.
    /// </summary>
    [DomName("defaultSelected")]
    bool IsDefaultSelected { get; set; }

    /// <summary>
    /// Gets or sets if the option is currently selected.
    /// </summary>
    [DomName("selected")]
    bool IsSelected { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }

    /// <summary>
    /// Gets or sets the text of the option.
    /// </summary>
    [DomName("text")]
    string Text { get; set; }

    /// <summary>
    /// Gets the index of the option element.
    /// </summary>
    [DomName("index")]
    int Index { get; }
}
