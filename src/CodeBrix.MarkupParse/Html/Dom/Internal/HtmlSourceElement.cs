using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML source element.
/// </summary>
sealed class HtmlSourceElement : HtmlElement, IHtmlSourceElement
{
    #region ctor

    public HtmlSourceElement(Document owner, string prefix = null)
        : base(owner, TagNames.Source, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Media
    {
        get => this.GetOwnAttribute(AttributeNames.Media);
        set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string SourceSet
    {
        get => this.GetOwnAttribute(AttributeNames.SrcSet);
        set => this.SetOwnAttribute(AttributeNames.SrcSet, value);
    }

    public string Sizes
    {
        get => this.GetOwnAttribute(AttributeNames.Sizes);
        set => this.SetOwnAttribute(AttributeNames.Sizes, value);
    }

    #endregion
}
