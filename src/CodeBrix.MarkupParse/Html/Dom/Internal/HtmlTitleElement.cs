using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the title element.
/// </summary>
sealed class HtmlTitleElement : HtmlElement, IHtmlTitleElement
{
    #region ctor

    /// <summary>
    /// Creates a new HTML title element.
    /// </summary>
    public HtmlTitleElement(Document owner, string prefix = null)
        : base(owner, TagNames.Title, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the text of the title.
    /// </summary>
    public string Text
    {
        get => TextContent;
        set => TextContent = value;
    }

    #endregion
}
