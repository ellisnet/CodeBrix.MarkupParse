using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML paragraph element.
/// </summary>
sealed class HtmlParagraphElement : HtmlElement, IHtmlParagraphElement
{
    #region ctor

    public HtmlParagraphElement(Document owner, string prefix = null)
        : base(owner, TagNames.P, prefix, NodeFlags.Special | NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }

    #endregion

    #region Properties

    public HorizontalAlignment Align
    {
        get => this.GetOwnAttribute(AttributeNames.Align).ToEnum(HorizontalAlignment.Left);
        set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    #endregion
}
