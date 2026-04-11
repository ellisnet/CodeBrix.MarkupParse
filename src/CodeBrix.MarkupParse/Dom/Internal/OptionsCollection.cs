using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A collection specialized on IHtmlOptionElement elements.
/// </summary>
sealed class OptionsCollection : IHtmlOptionsCollection
{
    #region Fields

    private readonly IElement _parent;
    private readonly IEnumerable<IHtmlOptionElement> _options;

    #endregion

    #region ctor

    public OptionsCollection(IElement parent)
    {
        _parent = parent;
        _options = GetOptions();
    }

    #endregion

    #region Index

    public IHtmlOptionElement this[int index]
    {
        get { return GetOptionAt(index); }
    }

    public IHtmlOptionElement this[string name]
    {
        get 
        {
            if (name is { Length: > 0 })
            {
                foreach (var option in _options)
                {
                    if (option.Id.Is(name))
                    {
                        return option;
                    }
                }

                return _parent.Children[name] as IHtmlOptionElement;
            }

            return null;
        }
    }

    #endregion

    #region Properties

    public int SelectedIndex
    {
        get
        {
            var index = 0;

            foreach (var option in _options)
            {
                if (option.IsSelected)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
        set
        {
            var index = 0;

            foreach (var option in _options)
            {
                option.IsSelected = index++ == value;
            }
        }
    }

    public int Length => _options.Count();

    #endregion

    #region Methods

    public IHtmlOptionElement GetOptionAt(int index)
    {
        return _options.GetItemByIndex(index);
    }

    public void SetOptionAt(int index, IHtmlOptionElement value)
    {
        var child = GetOptionAt(index);

        if (child != null)
        {
            _parent.ReplaceChild(value, child);
        }
        else
        {
            _parent.AppendChild(value);
        }
    }

    public void Add(IHtmlOptionElement element, IHtmlElement before = null)
    {
        _parent.InsertBefore(element, before);
    }

    public void Add(IHtmlOptionsGroupElement element, IHtmlElement before = null)
    {
        _parent.InsertBefore(element, before);
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < Length)
        {
            var child = GetOptionAt(index);
            _parent.RemoveChild(child);
        }
    }

    #endregion

    #region Enumerator

    private IEnumerable<IHtmlOptionElement> GetOptions()
    {
        foreach (var child in _parent.ChildNodes)
        {

            if (child is IHtmlOptionsGroupElement optgroup)
            {
                foreach (var element in optgroup.ChildNodes)
                {

                    if (element is IHtmlOptionElement option)
                    {
                        yield return option;
                    }
                }
            }
            else if (child is IHtmlOptionElement)
            {
                yield return (IHtmlOptionElement)child;
            }
        }
    }

    public IEnumerator<IHtmlOptionElement> GetEnumerator()
    {
        return _options.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}
