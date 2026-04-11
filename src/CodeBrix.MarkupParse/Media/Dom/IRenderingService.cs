using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents a service for creating rendering contexts.
/// </summary>
public interface IRenderingService
{
    /// <summary>
    /// Checks if the given context is supported.
    /// </summary>
    /// <param name="contextId">The ID of the context.</param>
    /// <returns>True if the context is supported, otherwise false.</returns>
    bool IsSupportingContext(string contextId);

    /// <summary>
    /// Creates the given context or returns null, if this is not possible.
    /// </summary>
    /// <param name="host">The host the context.</param>
    /// <param name="contextId">The ID of the context.</param>
    /// <returns>The instance of the rendering context.</returns>
    IRenderingContext CreateContext(IHtmlCanvasElement host, string contextId);
}
