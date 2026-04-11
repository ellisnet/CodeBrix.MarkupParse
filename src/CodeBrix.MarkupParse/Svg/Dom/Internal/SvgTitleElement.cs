using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the title element of the SVG DOM.
/// </summary>
sealed class SvgTitleElement : SvgElement, ISvgTitleElement
{
    public SvgTitleElement(Document owner, string prefix = null)
        : base(owner, TagNames.Title, prefix, NodeFlags.HtmlTip | NodeFlags.Special | NodeFlags.Scoped)
    {
    }
}
