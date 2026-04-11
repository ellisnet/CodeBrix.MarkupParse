using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Defines how a DOMException should look like.
/// </summary>
[DomName("DOMException")]
public interface IDomException
{
    /// <summary>
    /// Gets the error code for this exception.
    /// </summary>
    [DomName("code")]
    int Code { get; }
}
