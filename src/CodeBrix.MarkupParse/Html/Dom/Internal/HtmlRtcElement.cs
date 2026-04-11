using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The rtc HTML element.
/// </summary>
sealed class HtmlRtcElement : HtmlElement
{
    public HtmlRtcElement(Document owner, string prefix = null)
        : base(owner, TagNames.Rtc, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }
}
