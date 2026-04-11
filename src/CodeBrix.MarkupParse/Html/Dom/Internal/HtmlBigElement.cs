using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The big HTML element.
/// </summary>
sealed class HtmlBigElement : HtmlElement
{
    public HtmlBigElement(Document owner, string prefix = null)
        : base(owner, TagNames.Big, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
