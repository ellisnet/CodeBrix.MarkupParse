using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The class for an unknown HTML element.
/// </summary>
sealed class HtmlUnknownElement : HtmlElement, IHtmlUnknownElement
{
    public HtmlUnknownElement(Document owner, string localName, string prefix = null, NodeFlags flags = NodeFlags.None)
        : base(owner, localName, prefix, flags)
    {
    }
}
