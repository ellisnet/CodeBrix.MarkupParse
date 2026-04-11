using CodeBrix.MarkupParse.Browser;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Construction;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML meta element.
/// </summary>
sealed class HtmlMetaElement : HtmlElement, IHtmlMetaElement, IConstructableMetaElement
{
    #region ctor

    public HtmlMetaElement(Document owner, string prefix = null)
        : base(owner, TagNames.Meta, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public string Content
    {
        get => this.GetOwnAttribute(AttributeNames.Content);
        set => this.SetOwnAttribute(AttributeNames.Content, value);
    }

    public string Charset
    {
        get => this.GetOwnAttribute(AttributeNames.Charset);
        set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string HttpEquivalent
    {
        get => this.GetOwnAttribute(AttributeNames.HttpEquiv);
        set => this.SetOwnAttribute(AttributeNames.HttpEquiv, value);
    }

    public string Scheme
    {
        get => this.GetOwnAttribute(AttributeNames.Scheme);
        set => this.SetOwnAttribute(AttributeNames.Scheme, value);
    }

    public string Name
    {
        get => this.GetOwnAttribute(AttributeNames.Name);
        set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    #endregion

    #region Methods

    public void Handle()
    {
        var handlers = Owner.Context.GetServices<IMetaHandler>();

        foreach (var handler in handlers)
        {
            handler.HandleContent(this);
        }
    }

    #endregion
}
