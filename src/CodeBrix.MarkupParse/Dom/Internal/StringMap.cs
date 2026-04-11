using CodeBrix.MarkupParse.Text;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a list of DOMTokens.
/// </summary>
sealed class StringMap : IStringMap
{
    #region Fields

    private readonly string _prefix;
    private readonly Element _parent;

    #endregion

    #region ctor

    internal StringMap(string prefix, Element parent)
    {
        _prefix = prefix;
        _parent = parent;
    }

    #endregion

    #region Index

    public string this[string name]
    {
        get => _parent.GetOwnAttribute(_prefix + Check(name));
        set => _parent.SetOwnAttribute(_prefix + Check(name), value);
    }

    #endregion

    #region Methods

    public void Remove(string name)
    {
        if (Contains(name))
        {
            this[name] = null;
        }
    }

    public bool Contains(string name)
    {
        return _parent.HasOwnAttribute(_prefix + Check(name));
    }

    #endregion

    #region Helper

    private static string Check(string name)
    {
        if (name.StartsWith(TagNames.Xml, StringComparison.OrdinalIgnoreCase))
        {
            throw new DomException(DomError.Syntax);
        }

        if (name.IndexOf(Symbols.Semicolon) >= 0)
        {
            throw new DomException(DomError.Syntax);
        }

        for (var i = 0; i < name.Length; i++)
        {
            if (name[i].IsUppercaseAscii())
            {
                throw new DomException(DomError.Syntax);
            }
        }

        return name;
    }

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        foreach (var attr in _parent.Attributes)
        {
            if (attr.NamespaceUri is null && attr.Name.StartsWith(_prefix, StringComparison.OrdinalIgnoreCase))
            {
                var name = attr.Name.Remove(0, _prefix.Length);
                var value = attr.Value;
                yield return new KeyValuePair<string, string>(name, value);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}
