using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the output HTML element.
/// </summary>
[DomName("HTMLOutputElement")]
public interface IHtmlOutputElement : IHtmlElement, IValidation
{
    /// <summary>
    /// Gets or sets the IDs of the input elements.
    /// </summary>
    [DomName("htmlFor")]
    ISettableTokenList HtmlFor { get; }

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
    /// Gets the list of assigned labels.
    /// </summary>
    [DomName("labels")]
    INodeList Labels { get; }

    /// <summary>
    /// Gets the type of input control (output).
    /// </summary>
    [DomName("type")]
    string Type { get; }

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
}
