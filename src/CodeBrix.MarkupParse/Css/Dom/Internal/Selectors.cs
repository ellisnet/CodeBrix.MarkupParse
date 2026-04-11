using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// A list of selectors, which is the basis for CompoundSelector and
/// SelectorGroup.
/// </summary>
abstract class Selectors : IEnumerable<ISelector>
{
    #region Fields

    protected readonly List<ISelector> _selectors;

    #endregion

    #region ctor

    public Selectors()
    {
        _selectors = [];
    }

    #endregion

    #region Properties

    public Priority Specificity => ComputeSpecificity();

    public string Text => Stringify();

    public int Length => _selectors.Count;

    public ISelector this[int index]
    {
        get => _selectors[index];
        set => _selectors[index] = value;
    }

    #endregion

    #region Methods

    protected abstract Priority ComputeSpecificity();

    protected abstract string Stringify();

    public void Add(ISelector selector) => _selectors.Add(selector);

    public void Remove(ISelector selector) => _selectors.Remove(selector);

    #endregion

    #region IEnumerable implementation

    public IEnumerator<ISelector> GetEnumerator() => _selectors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
