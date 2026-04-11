using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The address HTML element.
/// </summary>
sealed class HtmlAddressElement : HtmlElement
{
    public HtmlAddressElement(Document owner, string prefix = null)
        : base(owner, TagNames.Address, prefix, NodeFlags.Special)
    {
    }
}
