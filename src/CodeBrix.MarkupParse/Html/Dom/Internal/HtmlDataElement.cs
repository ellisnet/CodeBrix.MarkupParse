using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML data element.
/// </summary>
sealed class HtmlDataElement : HtmlElement, IHtmlDataElement
{
    #region ctor

    public HtmlDataElement(Document owner, string prefix = null)
        : base(owner, TagNames.Data, prefix)
    {
    }

    #endregion

    #region Properties

    public string Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value);
        set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    #endregion
}
