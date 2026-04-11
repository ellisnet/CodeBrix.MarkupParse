using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The DOM Object representing the unordered list.
/// </summary>
sealed class HtmlUnorderedListElement : HtmlElement, IHtmlUnorderedListElement
{
    public HtmlUnorderedListElement(Document owner, string prefix = null)
        : base(owner, TagNames.Ul, prefix, NodeFlags.Special | NodeFlags.HtmlListScoped)
    {
    }
}
