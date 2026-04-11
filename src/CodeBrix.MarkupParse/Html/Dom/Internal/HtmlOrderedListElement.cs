using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML ordered list (ol) element.
/// </summary>
sealed class HtmlOrderedListElement : HtmlElement, IHtmlOrderedListElement
{
    #region ctor

    public HtmlOrderedListElement(Document owner, string prefix = null)
        : base(owner, TagNames.Ol, prefix, NodeFlags.Special | NodeFlags.HtmlListScoped)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets if the order is reversed.
    /// </summary>
    public bool IsReversed
    {
        get => this.GetBoolAttribute(AttributeNames.Reversed);
        set => this.SetBoolAttribute(AttributeNames.Reversed, value);
    }

    /// <summary>
    /// Gets or sets the start of the numbering.
    /// </summary>
    public int Start
    {
        get => this.GetOwnAttribute(AttributeNames.Start).ToInteger(1);
        set => this.SetOwnAttribute(AttributeNames.Start, value.ToString());
    }

    /// <summary>
    /// Gets or sets a value within [ 1, a, A, i, I ].
    /// </summary>
    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    #endregion
}
