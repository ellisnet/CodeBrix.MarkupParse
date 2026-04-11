using CodeBrix.MarkupParse.Html.Dom;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Defines the interface to be used for handling meta data.
/// </summary>
public interface IMetaHandler
{
    /// <summary>
    /// Handles the content of the given HTML meta element.
    /// </summary>
    /// <param name="element">The meta element.</param>
    void HandleContent(IHtmlMetaElement element);
}
