using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the hr element.
/// </summary>
sealed class HtmlHrElement : HtmlElement, IHtmlHrElement
{
    public HtmlHrElement(Document owner, string prefix = null)
        : base(owner, TagNames.Hr, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }
}
