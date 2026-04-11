using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML applet element.
/// </summary>
[DomHistorical]
sealed class HtmlAppletElement : HtmlElement
{
    public HtmlAppletElement(Document owner, string prefix = null)
        : base(owner, TagNames.Applet, prefix, NodeFlags.Special | NodeFlags.Scoped)
    {
    }
}
