using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The nobr HTML element.
/// </summary>
sealed class HtmlNoNewlineElement : HtmlElement
{
    public HtmlNoNewlineElement(Document owner, string prefix = null)
        : base(owner, TagNames.NoBr, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
