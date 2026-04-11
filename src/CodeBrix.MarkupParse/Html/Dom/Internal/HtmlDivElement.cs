using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML div element.
/// </summary>
sealed class HtmlDivElement : HtmlElement, IHtmlDivElement
{
    public HtmlDivElement(Document owner, string prefix = null)
        : base(owner, TagNames.Div, prefix, NodeFlags.Special)
    {
    }
}
