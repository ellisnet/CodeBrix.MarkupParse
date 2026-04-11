using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The rb HTML element.
/// </summary>
sealed class HtmlRbElement : HtmlElement
{
    public HtmlRbElement(Document owner, string prefix = null)
        : base(owner, TagNames.Rb, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }
}
