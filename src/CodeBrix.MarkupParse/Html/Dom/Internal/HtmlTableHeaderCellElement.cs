using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the object for HTML th elements.
/// </summary>
sealed class HtmlTableHeaderCellElement : HtmlTableCellElement, IHtmlTableHeaderCellElement
{
    public HtmlTableHeaderCellElement(Document owner, string prefix = null)
        : base(owner, TagNames.Th, prefix)
    {
    }
}
