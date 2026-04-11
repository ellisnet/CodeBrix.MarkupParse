using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the desc element of the SVG DOM.
/// </summary>
sealed class SvgDescElement : SvgElement, ISvgDescriptionElement
{
    public SvgDescElement(Document owner, string prefix = null)
        : base(owner, TagNames.Desc, prefix, NodeFlags.HtmlTip | NodeFlags.Special | NodeFlags.Scoped)
    {
    }
}
