using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML br element.
/// </summary>
sealed class HtmlBreakRowElement : HtmlElement, IHtmlBreakRowElement
{
    public HtmlBreakRowElement(Document owner, string prefix = null)
        : base(owner, TagNames.Br, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }
}
