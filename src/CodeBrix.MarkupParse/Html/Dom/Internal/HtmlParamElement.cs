using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a param element.
/// </summary>
sealed class HtmlParamElement : HtmlElement, IHtmlParamElement
{
    #region ctor

    public HtmlParamElement(Document owner, string prefix = null)
        : base(owner, TagNames.Param, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public string Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value);
        set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public string Name
    {
        get => this.GetOwnAttribute(AttributeNames.Name);
        set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    #endregion
}
