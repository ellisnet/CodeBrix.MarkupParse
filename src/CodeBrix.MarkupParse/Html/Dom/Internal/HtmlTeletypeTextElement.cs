using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The tt HTML element.
/// </summary>
sealed class HtmlTeletypeTextElement : HtmlElement
{
    public HtmlTeletypeTextElement(Document owner, string prefix = null)
        : base(owner, TagNames.Tt, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
