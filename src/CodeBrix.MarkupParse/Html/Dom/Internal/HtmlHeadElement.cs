using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML head element.
/// </summary>
sealed class HtmlHeadElement : HtmlElement, IHtmlHeadElement
{
    public HtmlHeadElement(Document owner, string prefix = null)
        : base(owner, TagNames.Head, prefix, NodeFlags.Special)
    {
    }
}
