using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The small HTML element.
/// </summary>
sealed class HtmlSmallElement : HtmlElement
{
    public HtmlSmallElement(Document owner, string prefix = null)
        : base(owner, TagNames.Small, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
