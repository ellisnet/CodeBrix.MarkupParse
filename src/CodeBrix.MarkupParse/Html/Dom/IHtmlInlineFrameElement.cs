using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the iframe HTML element.
/// </summary>
[DomName("HTMLIFrameElement")]
public interface IHtmlInlineFrameElement : IHtmlElement, ILoadableElement
{
    /// <summary>
    /// Gets or sets the frame source.
    /// </summary>
    [DomName("src")]
    string Source { get; set; }

    /// <summary>
    /// Gets the content of the page that the nested browsing context is to contain.
    /// </summary>
    [DomName("srcdoc")]
    string ContentHtml { get; set; }

    /// <summary>
    /// Gets or sets the name of the frame.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets the tokens of the sandbox attribute.
    /// </summary>
    [DomName("sandbox")]
    ISettableTokenList Sandbox { get; }

    /// <summary>
    /// Gets or sets if the seamless attribute has been set.
    /// </summary>
    [DomName("seamless")]
    bool IsSeamless { get; set; }

    /// <summary>
    /// Gets or sets if the frame's content can trigger the fullscreen mode.
    /// </summary>
    [DomName("allowFullscreen")]
    bool IsFullscreenAllowed { get; set; }

    /// <summary>
    /// Gets or sets if the frame's content can trigger a payment request.
    /// </summary>
    [DomName("allowPaymentRequest")]
    bool IsPaymentRequestAllowed { get; set; }

    /// <summary>
    /// Gets or sets the frame's referrer policy.
    /// </summary>
    [DomName("referrerPolicy")]
    string ReferrerPolicy { get; set; }

    /// <summary>
    /// Gets or sets the display width of the frame.
    /// </summary>
    [DomName("width")]
    int DisplayWidth { get; set; }

    /// <summary>
    /// Gets or sets the display height of the frame.
    /// </summary>
    [DomName("height")]
    int DisplayHeight { get; set; }

    /// <summary>
    /// Gets the document this frame contains, if there is any.
    /// </summary>
    [DomName("contentDocument")]
    IDocument ContentDocument { get; }

    /// <summary>
    /// Gets the frame's parent's window context.
    /// </summary>
    [DomName("contentWindow")]
    IWindow ContentWindow { get; }
}
