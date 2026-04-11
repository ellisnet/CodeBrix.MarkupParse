using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML html element.
/// </summary>
sealed class HtmlHtmlElement : HtmlElement, IHtmlHtmlElement
{
    #region ctor

    public HtmlHtmlElement(Document owner, string prefix = null)
        : base(owner, TagNames.Html, prefix, NodeFlags.Special | NodeFlags.ImplicitlyClosed | NodeFlags.Scoped | NodeFlags.HtmlTableScoped | NodeFlags.HtmlTableSectionScoped)
    {
    }

    #endregion

    #region Properties

    public string Manifest
    {
        get => this.GetOwnAttribute(AttributeNames.Manifest);
        set => this.SetOwnAttribute(AttributeNames.Manifest, value);
    }

    #endregion
}
