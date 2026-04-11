using CodeBrix.MarkupParse.Dom;

namespace CodeBrix.MarkupParse.Html.Dom;

/// <summary>
/// Represents the HTML isindex element.
/// </summary>
sealed class HtmlIsIndexElement : HtmlElement
{
    #region ctor

    public HtmlIsIndexElement(Document owner, string prefix = null)
        : base(owner, TagNames.IsIndex, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    public IHtmlFormElement Form
    {
        get;
        internal set;
    }

    public string Prompt
    {
        get => this.GetOwnAttribute(AttributeNames.Prompt);
        set => this.SetOwnAttribute(AttributeNames.Prompt, value);
    }

    #endregion
}
