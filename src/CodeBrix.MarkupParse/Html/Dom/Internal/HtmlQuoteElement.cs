using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Rperesents the HTML quote element.
/// </summary>
sealed class HtmlQuoteElement : HtmlElement, IHtmlQuoteElement
{
    #region ctor

    public HtmlQuoteElement(Document owner, string name = null, string prefix = null)
        : base(owner, name ?? TagNames.Quote, prefix, name.Is(TagNames.BlockQuote) ? NodeFlags.Special : NodeFlags.None)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the citation.
    /// </summary>
    public string Citation
    {
        get => this.GetOwnAttribute(AttributeNames.Cite);
        set => this.SetOwnAttribute(AttributeNames.Cite, value);
    }

    #endregion
}
