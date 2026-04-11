using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML bgsound element.
/// </summary>
[DomHistorical]
sealed class HtmlBgsoundElement : HtmlElement
{
    public HtmlBgsoundElement(Document owner, string prefix = null)
        : base(owner, TagNames.Bgsound, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }
}
