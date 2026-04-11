using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The strong HTML element.
/// </summary>
sealed class HtmlStrongElement : HtmlElement
{
    public HtmlStrongElement(Document owner, string prefix = null)
        : base(owner, TagNames.Strong, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
