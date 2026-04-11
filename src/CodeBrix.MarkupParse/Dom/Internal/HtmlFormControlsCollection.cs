using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A specialized collection containing elements of type HTMLFormControlElement.
/// </summary>
sealed class HtmlFormControlsCollection : IHtmlFormControlsCollection
{
    #region Fields

    private readonly IEnumerable<HtmlFormControlElement> _elements;

    #endregion

    #region ctor

    public HtmlFormControlsCollection(IElement form, IElement root = null)
    {
        root ??= form.Owner!.DocumentElement;

        _elements = root.GetNodes<HtmlFormControlElement>().Where(m =>
        {
            if (object.ReferenceEquals(m.Form, form))
            {

                if (m is not IHtmlInputElement input || !input.Type.Is(InputTypeNames.Image))
                {
                    return true;
                }
            }

            return false;
        });
    }

    #endregion

    #region Properties

    public int Length => _elements.Count();

    #endregion

    #region HtmlFormControlElement Implementation

    public HtmlFormControlElement this[int index] => _elements.GetItemByIndex(index);

    public HtmlFormControlElement this[string id] => _elements.GetElementById(id);

    public IEnumerator<HtmlFormControlElement> GetEnumerator() => _elements.GetEnumerator();

    #endregion

    #region IHtmlCollection Implementation

    IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();

IHtmlElement IReadOnlyList<IHtmlElement>.this[int index] => this[index];

    IHtmlElement IHtmlCollection<IHtmlElement>.this[string id] => this[id];

    IEnumerator<IHtmlElement> IEnumerable<IHtmlElement>.GetEnumerator() => _elements.GetEnumerator();

    #endregion
}
