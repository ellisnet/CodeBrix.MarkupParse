using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents the typedef for any rendering context.
/// This is shown is the base interface for all rendering
/// contexts.
/// </summary>
[DomName("RenderingContext")]
public interface IRenderingContext
{
    /// <summary>
    /// Gets the ID of the rendering context.
    /// </summary>
    string ContextId { get; }

    /// <summary>
    /// Gets if the context's bitmap mode is fixed.
    /// </summary>
    bool IsFixed { get; }

    /// <summary>
    /// Gets the bound host of the context.
    /// </summary>
    IHtmlCanvasElement Host { get; }

    /// <summary>
    /// Converts the current data to the given image format.
    /// </summary>
    /// <param name="type">The type of the image format.</param>
    /// <returns>The raw content bytes of the image.</returns>
    byte[] ToImage(string type);
}
