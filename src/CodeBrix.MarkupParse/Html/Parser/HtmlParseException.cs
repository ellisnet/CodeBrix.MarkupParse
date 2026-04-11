using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Parser; //Was previously: namespace AngleSharp.Html.Parser

/// <summary>
/// Exception that is thrown if an ill-formatted HTML document is parsed
/// in strict mode.
/// </summary>
public class HtmlParseException : Exception
{
    #region ctor

    /// <summary>
    /// Creates a new HtmlParseException.
    /// </summary>
    /// <param name="code">The provided error code.</param>
    /// <param name="message">The associated error message.</param>
    /// <param name="position">The position in the source.</param>
    /// 
    public HtmlParseException(int code, string message, TextPosition position)
        : base(message)
    {
        Code = code;
        Position = position;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the position of the error.
    /// </summary>
    public TextPosition Position { get; }

    /// <summary>
    /// Gets the provided error code.
    /// </summary>
    public int Code { get; }

    #endregion
}
