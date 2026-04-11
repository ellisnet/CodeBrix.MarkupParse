using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a list of query parameters.
/// </summary>
[DomName("URLSearchParams")]
[DomExposed("Window")]
[DomExposed("Worker")]
public class UrlSearchParams
{
    #region Fields

    private readonly List<KeyValuePair<string, string>> _values;
    private readonly Url _parent;
    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    [DomConstructor]
    public UrlSearchParams() => _values = [];

    internal UrlSearchParams(Url parent) : this(parent.Query ?? string.Empty)
    {
        _parent = parent;
    }

    /// <summary>
    /// Creates a new instance filled from the provided string.
    /// </summary>
    [DomConstructor]
    public UrlSearchParams(string init) : this() => ChangeTo(init, false);

    #endregion

    #region Methods

    internal void Reset() => _values.Clear();

    internal void ChangeTo(string query, bool fromParent)
    {
        Reset();

        if (query is "")
        {
            return;
        }

        foreach (var pair in query.Split('&'))
        {
            var kvp = pair.Split('=');

            if (kvp.Length > 1)
            {
                AppendCore(Decode(kvp[0]), Decode(kvp[1]));
            }
            else
            {
                AppendCore(Decode(pair), string.Empty);
            }
        }

        RaiseChanged(fromParent);
    }

    /// <summary>
    /// Appends another value for the given search param name.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    /// <param name="value">The value of the param.</param>
    [DomName("append")]
    public void Append(string name, string value)
    {
        AppendCore(name, value);
        RaiseChanged(false);
    }

    private void AppendCore(string name, string value)
    {
        _values.Add(new KeyValuePair<string, string>(name, value));
    }

    /// <summary>
    /// Deletes the values of the search param name.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    [DomName("delete")]
    public void Delete(string name)
    {
        DeleteCore(name);
        RaiseChanged(false);
    }

    private void DeleteCore(string name)
    {
        _values.RemoveAll(p => p.Key == name);
    }

    /// <summary>
    /// Gets the first value of the given search param name, if any.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    /// <returns>The value of the param, if any.</returns>
    [DomName("get")]
    public string Get(string name) => _values.Find(p => p.Key == name).Value;

    /// <summary>
    /// Gets all values for the given search param name.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    /// <returns>The list with all stored values.</returns>
    [DomName("getAll")]
    public string[] GetAll(string name) => _values.FindAll(p => p.Key == name).Select(m => m.Value).ToArray();

    /// <summary>
    /// Checks if a search param with the given name exists.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    /// <returns>True if such a param exists, otherwise false.</returns>
    [DomName("has")]
    public bool Has(string name) => _values.Any(p => p.Key == name);

    /// <summary>
    /// Sets the given search param.
    /// </summary>
    /// <param name="name">The name of the param.</param>
    /// <param name="value">The value of the param.</param>
    [DomName("set")]
    public void Set(string name, string value)
    {
        if (Has(name))
        {
            var index = _values.FindIndex(p => p.Key == name);
            DeleteCore(name);
            _values.Insert(index, new KeyValuePair<string, string>(name, value));
        }
        else
        {
            AppendCore(name, value);
        }

        RaiseChanged(false);
    }

    /// <summary>
    /// Sorts the underlying list.
    /// </summary>
    [DomName("sort")]
    public void Sort()
    {
        _values.Sort((a, b) => a.Key.CompareTo(b.Key));
        RaiseChanged(false);
    }

    /// <inheritdoc />
    public override string ToString() => string.Join("&", _values.Select(p => $"{Encode(p.Key)}={Encode(p.Value)}"));

    #endregion

    #region Helpers

    private static string Encode(string value)
    {
        var sb = StringBuilderPool.Obtain();

        foreach (var chr in value)
        {
            if (chr.IsAlphanumericAscii() || chr is Symbols.Minus or Symbols.Underscore or Symbols.ExclamationMark or Symbols.Asterisk or Symbols.ReverseSolidus or Symbols.RoundBracketOpen or Symbols.RoundBracketClose or Symbols.Tilde)
            {
                sb.Append(chr);
            }
            else
            {
                sb.Append(Symbols.Percent);
                sb.Append(((int)chr).ToString("X2"));
            }
        }

        return sb.ToPool();
    }

    private static string Decode(string value)
    {
        var sb = StringBuilderPool.Obtain();

        for (var i = 0; i < value.Length; i++)
        {
            var chr = value[i];

            if (chr is Symbols.Percent && i + 2 < value.Length)
            {
                var count = value.Substring(i + 1, 2).FromHex();
                sb.Append((char)count);
                i += 2;
            }
            else
            {
                sb.Append(chr);
            }
        }

        return sb.ToPool();
    }

    private void RaiseChanged(bool fromParent)
    {
        if (!fromParent)
        {
            var qs = ToString();
            _parent?.ParseQuery(qs, 0, qs.Length, true, true);
        }
    }

    #endregion
}
