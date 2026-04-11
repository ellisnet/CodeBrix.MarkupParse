using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML dir element.
/// This element is obsolete since HTML 4.01.
/// </summary>
[DomHistorical]
sealed class HtmlDirectoryElement : HtmlElement
{
    public HtmlDirectoryElement(Document owner, string prefix = null)
        : base (owner, TagNames.Dir, prefix, NodeFlags.Special)
    {
    }
}
