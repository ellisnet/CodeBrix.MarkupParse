using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an unknown HTML element.
/// </summary>
[DomName("HTMLUnknownElement")]
public interface IHtmlUnknownElement : IHtmlElement
{
}
