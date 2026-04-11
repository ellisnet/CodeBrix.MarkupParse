using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The s HTML element.
/// </summary>
sealed class HtmlStruckElement : HtmlElement
{
    public HtmlStruckElement(Document owner, string prefix = null)
        : base(owner, TagNames.S, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
