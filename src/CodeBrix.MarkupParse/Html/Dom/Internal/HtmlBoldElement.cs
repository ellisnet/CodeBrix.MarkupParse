using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The bold HTML element.
/// </summary>
sealed class HtmlBoldElement : HtmlElement
{
    public HtmlBoldElement(Document owner, string prefix = null)
        : base(owner, TagNames.B, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
