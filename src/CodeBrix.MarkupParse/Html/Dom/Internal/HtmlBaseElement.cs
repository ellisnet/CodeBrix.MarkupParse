using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML base element.
/// </summary>
sealed class HtmlBaseElement : HtmlElement, IHtmlBaseElement
{
    #region ctor

    public HtmlBaseElement(Document owner, string prefix = null)
        : base(owner, TagNames.Base, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public string Href
    {
        get => this.GetOwnAttribute(AttributeNames.Href);
        set => this.SetOwnAttribute(AttributeNames.Href, value);
    }

    public string Target
    {
        get => this.GetOwnAttribute(AttributeNames.Target);
        set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();

        var href = this.GetOwnAttribute(AttributeNames.Href);

        if (href != null)
        {
            UpdateUrl(href);
        }
    }

    internal void UpdateUrl(string url)
    {
        Owner.BaseUrl = new Url(Owner.DocumentUrl, url ?? string.Empty);
    }

    #endregion
}
