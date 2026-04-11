using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the progress HTML element.
/// </summary>
[DomName("HTMLProgressElement")]
public interface IHtmlProgressElement : IHtmlElement, ILabelabelElement
{
    /// <summary>
    /// Gets or sets the current value.
    /// </summary>
    [DomName("value")]
    double Value { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [DomName("max")]
    double Maximum { get; set; }

    /// <summary>
    /// Gets the position.
    /// </summary>
    [DomName("position")]
    double Position { get; }
}
