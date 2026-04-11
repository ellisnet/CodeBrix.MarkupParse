using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The strike HTML element.
/// </summary>
sealed class HtmlStrikeElement : HtmlElement
{
    public HtmlStrikeElement(Document owner, string prefix = null)
        : base(owner, TagNames.Strike, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
