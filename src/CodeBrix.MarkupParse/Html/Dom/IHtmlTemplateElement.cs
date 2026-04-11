using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the template HTML element.
/// </summary>
[DomName("HTMLTemplateElement")]
public interface IHtmlTemplateElement : IHtmlElement
{
    /// <summary>
    /// Gets the template's content for cloning.
    /// </summary>
    [DomName("content")]
    IDocumentFragment Content { get; }
}
