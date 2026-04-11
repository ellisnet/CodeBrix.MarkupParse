using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML dl element.
/// </summary>
sealed class HtmlDefinitionListElement : HtmlElement
{
    public HtmlDefinitionListElement(Document owner, string prefix = null)
        : base(owner, TagNames.Dl, prefix, NodeFlags.Special)
    {
    }
}
