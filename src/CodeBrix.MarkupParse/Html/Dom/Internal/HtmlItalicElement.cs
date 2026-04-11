using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The i HTML element.
/// </summary>
sealed class HtmlItalicElement : HtmlElement
{
    public HtmlItalicElement(Document owner, string prefix = null)
        : base(owner, TagNames.I, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
