using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Html.Dom;

/// <summary>
/// Represents the HTML selectedcontent element.
/// </summary>
sealed class HtmlSelectedContentElement : HtmlElement
{
    #region ctor

    public HtmlSelectedContentElement(Document owner, string prefix = null)
        : base(owner, TagNames.SelectedContent, prefix)
    {
    }

    #endregion
}
