using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The rt element.
/// </summary>
sealed class HtmlRtElement : HtmlElement
{
    public HtmlRtElement(Document owner, string prefix = null)
        : base(owner, TagNames.Rt, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }
}
