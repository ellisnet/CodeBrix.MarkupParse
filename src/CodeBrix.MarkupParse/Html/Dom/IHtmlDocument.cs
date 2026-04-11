using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Serves as an entry point to the content of an HTML document.
/// </summary>
[DomName("HTMLDocument")]
public interface IHtmlDocument : IDocument
{
}
