using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The em HTML element.
/// </summary>
sealed class HtmlEmphasizeElement : HtmlElement
{
    public HtmlEmphasizeElement(Document owner, string prefix = null)
        : base(owner, TagNames.Em, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
