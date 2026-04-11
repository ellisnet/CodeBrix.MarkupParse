using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the foreign object element of the SVG DOM.
/// </summary>
sealed class SvgForeignObjectElement : SvgElement, ISvgForeignObjectElement
{
    public SvgForeignObjectElement(Document owner, string prefix = null)
        : base(owner, TagNames.ForeignObject, prefix, NodeFlags.HtmlTip | NodeFlags.Special | NodeFlags.Scoped)
    {
    }
}
