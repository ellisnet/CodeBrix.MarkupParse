using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML wbr (word-break-opportunity) element.
/// This element is used to indicate that the position is a good
/// point for inserting a possible line-break.
/// </summary>
sealed class HtmlWbrElement : HtmlElement
{
    public HtmlWbrElement(Document owner, string prefix = null)
        : base(owner, TagNames.Wbr, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }
}
