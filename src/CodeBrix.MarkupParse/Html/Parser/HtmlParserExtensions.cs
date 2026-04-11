using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Html.Parser; //Was previously: namespace AngleSharp.Html.Parser

/// <summary>
/// Extensions for the IHtmlParser instances.
/// </summary>
public static class HtmlParserExtensions
{
    /// <summary>
    /// Parses the string asynchronously.
    /// </summary>
    public static Task<IHtmlDocument> ParseDocumentAsync(this IHtmlParser parser, string source) => parser.ParseDocumentAsync(source, CancellationToken.None);

    /// <summary>
    /// Parses the stream asynchronously.
    /// </summary>
    public static Task<IHtmlDocument> ParseDocumentAsync(this IHtmlParser parser, Stream source) => parser.ParseDocumentAsync(source, CancellationToken.None);

    /// <summary>
    /// Parses the string asynchronously.
    /// </summary>
    public static Task<IHtmlHeadElement> ParseHeadAsync(this IHtmlParser parser, string source) => parser.ParseHeadAsync(source, CancellationToken.None);

    /// <summary>
    /// Parses the stream asynchronously.
    /// </summary>
    public static Task<IHtmlHeadElement> ParseHeadAsync(this IHtmlParser parser, Stream source) => parser.ParseHeadAsync(source, CancellationToken.None);

    /// <summary>
    /// Populates the given document asynchronously.
    /// </summary>
    public static Task<IDocument> ParseDocumentAsync(this IHtmlParser parser, IDocument document) => parser.ParseDocumentAsync(document, CancellationToken.None);
}
