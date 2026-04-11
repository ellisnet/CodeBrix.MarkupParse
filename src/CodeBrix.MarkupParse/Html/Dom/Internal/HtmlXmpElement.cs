using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The xmp HTML element.
/// </summary>
sealed class HtmlXmpElement : HtmlElement
{
    public HtmlXmpElement(Document owner, string prefix = null)
        : base(owner, TagNames.Xmp, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }
}
