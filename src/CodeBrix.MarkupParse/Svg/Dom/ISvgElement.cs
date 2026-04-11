using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// The SVGElement interface represents any SVG element. Some elements directly
/// implement this interface, other implement it via an interface that inherit it.
/// </summary>
[DomName("SVGElement")]
public interface ISvgElement : IElement
{
}
