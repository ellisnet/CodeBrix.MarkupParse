using CodeBrix.MarkupParse.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A specialized collection containing elements of type T.
/// </summary>
/// <typeparam name="T">The type of elements that is contained.</typeparam>
sealed class HtmlCollection<T> : IHtmlCollection<T>
    where T : class, IElement
{
    #region Fields

    private readonly IEnumerable<T> _elements;

    #endregion

    #region ctor

    public HtmlCollection(IEnumerable<T> elements)
    {
        _elements = elements;
    }

    public HtmlCollection(INode parent, bool deep = true, Func<T, bool> predicate = null)
    {
        _elements = parent.GetNodes(deep, predicate);
    }

    #endregion

    #region Index

    public T this[int index] => _elements.GetItemByIndex(index);

    public T this[string id] => _elements.GetElementById(id);

    #endregion

    #region Properties

    public int Length => _elements.Count();

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<T> GetEnumerator() => _elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();

    #endregion
}
