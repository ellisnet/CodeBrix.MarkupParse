using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the object for HTML td elements.
/// </summary>
sealed class HtmlTableDataCellElement : HtmlTableCellElement, IHtmlTableDataCellElement
{
    public HtmlTableDataCellElement(Document owner, string prefix = null)
        : base(owner, TagNames.Td, prefix)
    {
    }
}
