using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML details element.
/// </summary>
sealed class HtmlDetailsElement : HtmlElement, IHtmlDetailsElement
{
    #region ctor

    public HtmlDetailsElement(Document owner, string prefix = null)
        : base(owner, TagNames.Details, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    public bool IsOpen
    {
        get => this.GetBoolAttribute(AttributeNames.Open);
        set => this.SetBoolAttribute(AttributeNames.Open, value);
    }

    #endregion
}
