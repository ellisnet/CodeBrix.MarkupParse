using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the label HTML element.
/// </summary>
[DomName("HTMLLabelElement")]
public interface IHtmlLabelElement : IHtmlElement
{
    /// <summary>
    /// Gets the form element that the label is assigned for, if any.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets or sets the ID of the labeled control. Reflects the for attribute.
    /// </summary>
    [DomName("htmlFor")]
    string HtmlFor { get; set; }

    /// <summary>
    /// Gets the control that the label is assigned for, if any.
    /// </summary>
    [DomName("control")]
    IHtmlElement Control { get; }
}
