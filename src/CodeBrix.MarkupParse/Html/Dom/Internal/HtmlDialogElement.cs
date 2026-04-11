using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the object for HTML dialog elements.
/// </summary>
sealed class HtmlDialogElement : HtmlElement, IHtmlDialogElement
{
    #region Fields

    private string _returnValue;

    #endregion

    #region ctor

    public HtmlDialogElement(Document owner, string prefix = null)
        : base(owner, TagNames.Dialog, prefix)
    {
    }

    #endregion

    #region Properties

    public bool Open
    {
        get => this.GetBoolAttribute(AttributeNames.Open);
        set => this.SetBoolAttribute(AttributeNames.Open, value);
    }

    public string ReturnValue
    {
        get => _returnValue;
        set => _returnValue = value;
    }

    public void Show(IElement anchor = null)
    {
        Open = true;
        //TODO
    }

    public void ShowModal(IElement anchor = null)
    {
        Open = true;
        //TODO
    }

    public void Close(string returnValue = null)
    {
        Open = false;
        ReturnValue = returnValue;
    }

    #endregion
}
