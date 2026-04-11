using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The code HTML element.
/// </summary>
sealed class HtmlCodeElement : HtmlElement
{
    public HtmlCodeElement(Document owner, string prefix = null)
        : base(owner, TagNames.Code, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
