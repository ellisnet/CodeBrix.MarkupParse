using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The rp HTML element.
/// </summary>
sealed class HtmlRpElement : HtmlElement
{
    public HtmlRpElement(Document owner, string prefix = null)
        : base(owner, TagNames.Rp, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }
}
