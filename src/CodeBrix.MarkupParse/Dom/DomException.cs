using CodeBrix.MarkupParse.Common;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a DOM exception.
/// </summary>
public sealed class DomException : Exception, IDomException
{
    #region ctor

    /// <summary>
    /// Creates a new DOMException.
    /// </summary>
    /// <param name="code">The error code.</param>
    public DomException(DomError code)
        : base(code.GetMessage())
    {
        Code = (int)code;
        Name = code.ToString();
    }

    /// <summary>
    /// Creates a new DOMException with a custom message.
    /// </summary>
    /// <param name="message">The message to transport.</param>
    public DomException(string message)
    {
        Code = 0;
        Name = message;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the name of the error.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the error code for this exception.
    /// </summary>
    public int Code { get; }

    #endregion
}
