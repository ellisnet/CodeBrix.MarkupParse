using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the mod HTML element.
/// </summary>
[DomName("HTMLModElement")]
public interface IHtmlModElement : IHtmlElement
{
    /// <summary>
    /// Gets the cite HTML attribute, containing a URI of a
    /// resource explaining the change.
    /// </summary>
    [DomName("cite")]
    string Citation { get; set; }

    /// <summary>
    /// Gets the datetime HTML attribute, containing a date-and-time
    /// string representing a timestamp for the change.
    /// </summary>
    [DomName("datetime")]
    string DateTime { get; set; }
}
