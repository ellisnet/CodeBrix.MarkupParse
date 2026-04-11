using System;

namespace CodeBrix.MarkupParse.Css.Parser; //Was previously: namespace AngleSharp.Css.Parser

/// <summary>
/// The CSS selector token.
/// </summary>
readonly struct CssSelectorToken
{
    #region Fields

    private readonly CssTokenType _type;
    private readonly string _data;

    public static readonly CssSelectorToken Whitespace = new(CssTokenType.Whitespace, " ");

    #endregion

    #region ctor

    public CssSelectorToken(CssTokenType type, string data)
    {
        _type = type;
        _data = data;
    }

    #endregion

    #region Properties

    public CssTokenType Type => _type;

    public string Data => _data;

    #endregion
}
