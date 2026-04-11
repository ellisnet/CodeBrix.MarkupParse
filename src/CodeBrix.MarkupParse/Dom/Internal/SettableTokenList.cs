using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A list of tokens that can be modified.
/// </summary>
sealed class SettableTokenList : TokenList, ISettableTokenList
{
    #region ctor

    internal SettableTokenList(string value)
        : base(value)
    {
    }

    #endregion

    #region Properties

    public string Value
    {
        get => ToString();
        set => Update(value);
    }

    #endregion
}
