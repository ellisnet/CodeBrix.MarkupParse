using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The same as TokenList, except that it allows the underlying string to
/// be directly changed.
/// </summary>
[DomName("DOMSettableTokenList")]
public interface ISettableTokenList : ITokenList
{
    /// <summary>
    /// Gets or sets the underlying string.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }
}
