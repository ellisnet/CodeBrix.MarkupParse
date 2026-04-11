using CodeBrix.MarkupParse.Css.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Parser; //Was previously: namespace AngleSharp.Css.Parser

/// <summary>
/// Represents the parser for a selector.
/// </summary>
public interface ICssSelectorParser
{
    /// <summary>
    /// Takes a string and transforms it into a selector object.
    /// </summary>
    ISelector ParseSelector(string selectorText);
}
