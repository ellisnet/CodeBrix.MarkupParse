using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a link HTML element.
/// </summary>
[DomName("HTMLLinkElement")]
public interface IHtmlLinkElement : IHtmlElement, ILinkStyle, ILinkImport, ILoadableElement
{
    /// <summary>
    /// Gets or sets if the stylesheet is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets the URI for the target resource.
    /// </summary>
    [DomName("href")]
    string Href { get; set; }

    /// <summary>
    /// Gets or sets the forward relationship of the linked resource from the document to the resource.
    /// </summary>
    [DomName("rel")]
    string Relation { get; set; }

    /// <summary>
    /// Gets or sets the reverse relationship of the linked resource from the resource to the document.
    /// </summary>
    [DomName("rev")]
    string ReverseRelation { get; set; }

    /// <summary>
    /// Gets the list of relations contained in the rel attribute.
    /// </summary>
    [DomName("relList")]
    ITokenList RelationList { get; }

    /// <summary>
    /// Gets or sets the use with one or more target media.
    /// </summary>
    [DomName("media")]
    string Media { get; set; }

    /// <summary>
    /// Gets or sets the language code for the linked resource.
    /// </summary>
    [DomName("hreflang")]
    string TargetLanguage { get; set; }

    /// <summary>
    /// Gets or sets the content type of the style sheet language.
    /// </summary>
    [DomName("type")]
    string Type { get; set; }

    /// <summary>
    /// Gets the list of sizes defined in the sizes attribute.
    /// </summary>
    [DomName("sizes")]
    ISettableTokenList Sizes { get; }

    /// <summary>
    /// Gets or sets the linked source's integrity, if any.
    /// </summary>
    [DomName("integrity")]
    string Integrity { get; set; }

    /// <summary>
    /// Gets or sets the cross-origin attribute.
    /// </summary>
    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    /// <summary>
    /// Gets or sets the nonce attribute.
    /// </summary>
    [DomName("nonce")]
    string NumberUsedOnce { get; set; }
}
