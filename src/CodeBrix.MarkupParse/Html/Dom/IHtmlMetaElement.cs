using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the meta HTML element.
/// </summary>
[DomName("HTMLMetaElement")]
public interface IHtmlMetaElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the name of the meta element.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the equivalent in a meta element, which
    /// is effective if the server doesn't send a corresponding real header.
    /// </summary>
    [DomName("httpEquiv")]
    string HttpEquivalent { get; set; }

    /// <summary>
    /// Gets or sets the associated charset.
    /// </summary>
    string Charset { get; set; }

    /// <summary>
    /// Gets or sets the value of the content attribute of the meta element.
    /// </summary>
    [DomName("content")]
    string Content { get; set; }
}
