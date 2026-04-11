using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The u HTML element.
/// </summary>
sealed class HtmlUnderlineElement : HtmlElement
{
    public HtmlUnderlineElement(Document owner, string prefix = null)
        : base(owner, TagNames.U, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
