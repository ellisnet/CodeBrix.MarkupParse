using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML pre element.
/// </summary>
sealed class HtmlPreElement : HtmlElement, IHtmlPreElement
{
    public HtmlPreElement(Document owner, string prefix = null)
        : base(owner, TagNames.Pre, prefix, NodeFlags.Special | NodeFlags.LineTolerance)
    {
    }
}
