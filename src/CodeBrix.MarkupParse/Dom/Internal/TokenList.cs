using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A simple list of tokens that is immutable.
/// </summary>
class TokenList : ITokenList, IBindable
{
    #region Fields

    private readonly List<string> _tokens;

    #endregion

    #region Events

    public event Action<string> Changed;

    #endregion

    #region ctor

    internal TokenList(string value)
    {
        _tokens = [];
        Update(value);
    }

    #endregion

    #region Index

    public string this[int index] => _tokens[index];

    #endregion

    #region Properties

    public int Length => _tokens.Count;

    #endregion

    #region Methods

    public void Update(string value)
    {
        _tokens.Clear();

        if (value is { Length: > 0 })
        {
            var elements = value.SplitSpaces();

            for (var i = 0; i < elements.Length; i++)
            {
                if (!_tokens.Contains(elements[i]))
                {
                    _tokens.Add(elements[i]);
                }
            }
        }
    }

    public bool Contains(string token) => _tokens.Contains(token);

    public void Remove(params string[] tokens)
    {
        var changed = false;

        foreach (var token in tokens)
        {
            if (_tokens.Contains(token))
            {
                _tokens.Remove(token);
                changed = true;
            }
        }

        if (changed)
        {
            RaiseChanged();
        }
    }

    public void Add(params string[] tokens)
    {
        var changed = false;

        foreach (var token in tokens)
        {
            if (!_tokens.Contains(token))
            {
                _tokens.Add(token);
                changed = true;
            }
        }

        if (changed)
        {
            RaiseChanged();
        }
    }

    public bool Toggle(string token, bool force = false)
    {
        var contains = _tokens.Contains(token);

        if (contains && force)
        {
            return true;
        }

        if (contains)
        {
            _tokens.Remove(token);
        }
        else
        {
            _tokens.Add(token);
        }

        RaiseChanged();
        return !contains;
    }

    #endregion

    #region Helper

    private void RaiseChanged() => Changed?.Invoke(ToString());

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<string> GetEnumerator() => _tokens.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion

    #region String representation

    public override string ToString() => string.Join(" ", _tokens);

    #endregion
}
