using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom.Events;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the body HTML element.
/// </summary>
[DomName("HTMLBodyElement")]
public interface IHtmlBodyElement : IHtmlElement, IWindowEventHandlers
{
}
