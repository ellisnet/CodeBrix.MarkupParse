using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The time HTML element.
/// </summary>
sealed class HtmlTimeElement : HtmlElement, IHtmlTimeElement
{
    #region ctor

    public HtmlTimeElement(Document owner, string prefix = null)
        : base(owner, TagNames.Time, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    public string DateTime
    {
        get => this.GetOwnAttribute(AttributeNames.Datetime);
        set => this.SetOwnAttribute(AttributeNames.Datetime, value);
    }

    #endregion
}
