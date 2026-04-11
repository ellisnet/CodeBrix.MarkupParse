using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an anchor element.
/// </summary>
sealed class HtmlAnchorElement : HtmlUrlBaseElement, IHtmlAnchorElement
{
    #region ctor

    /// <summary>
    /// Creates a new anchor element.
    /// </summary>
    public HtmlAnchorElement(Document owner, string prefix = null)
        : base(owner, TagNames.A, prefix, NodeFlags.HtmlFormatting)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the character encoding for the target resource.
    /// </summary>
    public string Charset
    {
        get => this.GetOwnAttribute(AttributeNames.Charset);
        set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    /// <summary>
    /// Gets or sets the anchor name.
    /// </summary>
    public string Name
    {
        get => this.GetOwnAttribute(AttributeNames.Name);
        set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    /// <summary>
    /// Gets or sets the text of the anchor tag (same as TextContent).
    /// </summary>
    public string Text
    {
        get => TextContent;
        set => TextContent = value;
    }

    #endregion

    #region Helpers

    public override void DoFocus()
    {
        if (this.HasOwnAttribute(AttributeNames.Href))
        {
            IsFocused = true;
        }
    }

    #endregion
}
