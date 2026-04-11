using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a font element.
/// See (19) obsolete features of [WHATWG].
/// </summary>
[DomHistorical]
sealed class HtmlFontElement : HtmlElement
{
    public HtmlFontElement(Document owner, string prefix = null)
        : base(owner, TagNames.Font, prefix, NodeFlags.HtmlFormatting)
    {
    }
}
