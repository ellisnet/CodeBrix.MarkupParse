using CodeBrix.MarkupParse.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A general collection for all elements of type IElement.
/// </summary>
sealed class HtmlAllCollection : IHtmlAllCollection
{
    #region Fields

    private readonly IEnumerable<IElement> _elements;

    #endregion

    #region ctor

    public HtmlAllCollection(IDocument document)
    {
        _elements = document.GetNodes<IElement>();
    }

    #endregion

    #region Index

    public IElement this[int index]
    {
        get { return _elements.GetItemByIndex(index); }
    }

    public IElement this[string id]
    {
        get { return _elements.GetElementById(id); }
    }

    #endregion

    #region Properties

    public int Length => _elements.Count();

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<IElement> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    #endregion
}
