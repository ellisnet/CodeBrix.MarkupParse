using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the object HTML element.
/// </summary>
[DomName("HTMLObjectElement")]
public interface IHtmlObjectElement : IHtmlElement, IValidation, ILoadableElement
{
    /// <summary>
    /// Gets or sets the address of the resource.
    /// </summary>
    [DomName("data")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets the type of the resource. If present,
    /// the attribute must be a valid MIME type.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets an attribute whose presence indicates that the resource specified by the data
    /// attribute is only to be used if the value of the type attribute and the Content-Type of the
    /// aforementioned resource match.
    /// </summary>
    [DomName("typeMustMatch")]
    bool TypeMustMatch { get; set; }

    /// <summary>
    /// Gets or sets the name of the object.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the associated image map of the object if the object element represents an image.
    /// </summary>
    [DomName("useMap")]
    string UseMap { get; set; }

    /// <summary>
    /// Gets the associated HTML form element.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets or sets the display width of the object element.
    /// </summary>
    [DomName("width")]
    int DisplayWidth { get; set; }

    /// <summary>
    /// Gets or sets the display height of the object element.
    /// </summary>
    [DomName("height")]
    int DisplayHeight { get; set; }

    /// <summary>
    /// Gets the active document of the object element's nested browsing context, if it has one;
    /// otherwise returns null.
    /// </summary>
    [DomName("contentDocument")]
    IDocument ContentDocument { get; }

    /// <summary>
    /// Gets the object element's nested browsing context, if it has one; otherwise returns null.
    /// </summary>
    [DomName("contentWindow")]
    IWindow ContentWindow { get; }
}
