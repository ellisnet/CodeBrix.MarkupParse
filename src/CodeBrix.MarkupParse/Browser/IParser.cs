using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Defines the basic events for all parsers.
/// </summary>
public interface IParser : IEventTarget
{
    /// <summary>
    /// Fired when a parser is starting.
    /// </summary>
    event DomEventHandler Parsing;

    /// <summary>
    /// Fired when a parser is finished.
    /// </summary>
    event DomEventHandler Parsed;

    /// <summary>
    /// Fired when a parse error is encountered.
    /// </summary>
    event DomEventHandler Error;
}
