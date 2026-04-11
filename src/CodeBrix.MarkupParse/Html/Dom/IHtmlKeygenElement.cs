using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the keygen HTML element.
/// </summary>
[DomName("HTMLKeygenElement")]
public interface IHtmlKeygenElement : IHtmlElement, IValidation
{
    /// <summary>
    /// Gets or sets the autofocus HTML attribute, which indicates whether the
    /// control should have input focus when the page loads.
    /// </summary>
    [DomName("autofocus")]
    bool Autofocus { get; set; }

    /// <summary>
    /// Gets the list of assigned labels.
    /// </summary>
    [DomName("labels")]
    INodeList Labels { get; }

    /// <summary>
    /// Gets or sets if the keygen is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets the associated HTML form element.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets or sets the name of the element.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets the type of input control (keygen).
    /// </summary>
    [DomName("type")]
    string Type { get; }

    /// <summary>
    /// Gets or sets the type of encryption used.
    /// </summary>
    [DomName("keytype")]
    string KeyEncryption { get; set; }

    /// <summary>
    /// Gets or sets the challenge attribute.
    /// </summary>
    [DomName("challenge")]
    string Challenge { get; set; }
}
