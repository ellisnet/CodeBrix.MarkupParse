using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the circle element of the SVG DOM.
/// </summary>
sealed class SvgCircleElement : SvgElement, ISvgCircleElement
{
    public SvgCircleElement(Document owner, string prefix = null)
        : base(owner, TagNames.Circle, prefix)
    {
    }
}
