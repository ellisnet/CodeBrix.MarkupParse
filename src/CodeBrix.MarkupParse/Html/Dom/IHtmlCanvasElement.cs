using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Media.Dom;
using System;
using System.IO;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the canvas HTML element.
/// </summary>
[DomName("HTMLCanvasElement")]
public interface IHtmlCanvasElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the pixel width of the canvas element.
    /// </summary>
    [DomName("width")]
    int Width { get; set; }

    /// <summary>
    /// Gets or sets the pixel height of the canvas element.
    /// </summary>
    [DomName("height")]
    int Height { get; set; }

    /// <summary>
    /// Returns a Data URI with the bitmap data of the context.
    /// </summary>
    /// <param name="type">The type of image e.g image/png.</param>
    /// <returns>A data URI with the data if any.</returns>
    [DomName("toDataURL")]
    string ToDataUrl(string type = null);

    /// <summary>
    /// Creates a BLOB out of the canvas pixel data and passes it
    /// to the given callback.
    /// </summary>
    /// <param name="callback">The callback function.</param>
    /// <param name="type">The type of object to create.</param>
    [DomName("toBlob")]
    void ToBlob(Action<Stream> callback, string type = null);

    /// <summary>
    /// Gets the drawing context.
    /// </summary>
    /// <param name="contextId">A context id like 2d.</param>
    /// <returns>An object that defines the drawing context.</returns>
    [DomName("getContext")]
    IRenderingContext GetContext(string contextId);

    /// <summary>
    /// Changes the context the element is related to the given one.
    /// </summary>
    /// <param name="context">The new context.</param>
    [DomName("setContext")]
    void SetContext(IRenderingContext context);
    
    /// <summary>
    /// Gets an indicator if a context with the given parameters could be created.
    /// </summary>
    /// <param name="contextId">A context id like 2d.</param>
    /// <returns>True if the context is supported, otherwise false.</returns>
    [DomName("probablySupportsContext")]
    bool IsSupportingContext(string contextId);
}
