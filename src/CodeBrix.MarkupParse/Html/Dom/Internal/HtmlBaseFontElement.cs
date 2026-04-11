using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML basefont element.
/// Deprecated in HTML 4.01.
/// </summary>
[DomHistorical]
sealed class HtmlBaseFontElement : HtmlElement
{
    public HtmlBaseFontElement(Document owner, string prefix = null)
        : base(owner, TagNames.BaseFont, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
    }
}
