using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the script HTML element.
/// </summary>
[DomName("HTMLScriptElement")]
public interface IHtmlScriptElement : IHtmlElement, ILoadableElement
{
    /// <summary>
    /// Gets or sets the source URL of the script.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets or sets if the script should be run asynchronously.
    /// </summary>
    [DomName("async")]
    bool IsAsync { get; set; }

    /// <summary>
    /// Gets or sets if script execution should be deferred.
    /// </summary>
    [DomName("defer")]
    bool IsDeferred { get; set; }

    /// <summary>
    /// Gets or sets the type of script.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets or sets the character set of the script.
    /// </summary>
    [DomName("charset")]
    string CharacterSet { get; set; }

    /// <summary>
    /// Gets or sets the cross-origin attribute.
    /// </summary>
    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    /// <summary>
    /// Gets or sets the script's source code.
    /// </summary>
    [DomName("text")]
    string Text { get; set; }

    /// <summary>
    /// Gets or sets the linked source's integrity, if any.
    /// </summary>
    [DomName("integrity")]
    string Integrity { get; set; }
}
