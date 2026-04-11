using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the svg element of the SVG DOM.
/// </summary>
sealed class SvgSvgElement : SvgElement, ISvgSvgElement
{
    public SvgSvgElement(Document owner, string prefix = null)
        : base(owner, TagNames.Svg, prefix)
    {
    }
}
