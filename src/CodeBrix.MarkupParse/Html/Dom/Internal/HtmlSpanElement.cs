using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML span element.
/// </summary>
sealed class HtmlSpanElement : HtmlElement, IHtmlSpanElement
{
    public HtmlSpanElement(Document owner, string prefix = null)
        : base(owner, TagNames.Span, prefix)
    {
    }
}
