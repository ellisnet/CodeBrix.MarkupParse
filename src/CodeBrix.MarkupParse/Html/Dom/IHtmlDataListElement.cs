using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the datalist HTML element.
/// </summary>
[DomName("HTMLDataListElement")]
public interface IHtmlDataListElement : IHtmlElement
{
    /// <summary>
    /// Gets the associated options.
    /// </summary>
    [DomName("options")]
    IHtmlCollection<IHtmlOptionElement> Options { get; }
}
