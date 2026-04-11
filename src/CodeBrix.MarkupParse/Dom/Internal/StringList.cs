using CodeBrix.MarkupParse.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a string list.
/// </summary>
sealed class StringList : IStringList
{
    #region Fields

    private readonly IEnumerable<string> _list;

    #endregion

    #region ctor

    internal StringList(IEnumerable<string> list)
    {
        _list = list;
    }

    #endregion

    #region Index

    public string this[int index] => _list.GetItemByIndex(index);

    #endregion

    #region Properties

    public int Length => _list.Count();

    #endregion

    #region Methods

    public bool Contains(string entry) => _list.Contains(entry);

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<string> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

    #endregion
}
