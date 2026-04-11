using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the param HTML element.
/// </summary>
[DomName("HTMLParamElement")]
public interface IHtmlParamElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the name of the parameter.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the parameter.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }
}
